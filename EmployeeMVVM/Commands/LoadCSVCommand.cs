using EmployeeMVVM.Models;
using EmployeeMVVM.Services.EmployeeCreators;
using EmployeeMVVM.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeMVVM.Commands
{
    public class LoadCSVCommand : AsyncCommandBase
    {
        private readonly ManageCSVViewModel? _manageCSVViewModel;
        private readonly EmployeeList? _employees;
        public LoadCSVCommand(ManageCSVViewModel? manageCSVViewModel, EmployeeList? employeeList)
        {
            _employees = employeeList;
            _manageCSVViewModel = manageCSVViewModel;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            // Open CSV file -> send data to the database
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV files (*.csv)|*.csv";

            bool? opened = dialog.ShowDialog();
            if(opened != true)
            {
                return;
            }

            string filename = dialog.FileName;
            string fileNameCut = Path.GetFileName(filename);

            var employees = new List<Employee>();

            try
            {
                // reading csv
                employees = File.ReadAllLines(filename).Skip(1).Select(row => FromCsv(row)).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"When trying to read a file an exception was raised. {ex.Message}");
            }

            try
            {
                await _employees.CreateEmployeeRange(employees);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"These values are already in database! {ex.Message}",
                            "Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);

                _manageCSVViewModel?.UpdateEmployees(employees, fileNameCut);
                return;
            }


            _manageCSVViewModel?.UpdateEmployees(employees, fileNameCut);
        }
        private static Employee FromCsv(string csvline)
        {
            string[] values = csvline.Split(',');
            Employee employee = new Employee(
                int.Parse(values[0]),
                values[1],
                values[2],
                values[3],
                values[4]
                );

            return employee;
        }

    }
}
