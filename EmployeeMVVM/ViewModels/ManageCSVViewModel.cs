using EmployeeMVVM.Commands;
using EmployeeMVVM.Models;
using EmployeeMVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EmployeeMVVM.ViewModels
{
    public class ManageCSVViewModel : ViewModelBase
    {

        private readonly ObservableCollection<EmployeeViewModel> _employees;
        public IEnumerable<EmployeeViewModel> Employees => _employees;

        private string? _csvFileName;
        public string? CsvFileName
        {
            get 
            { 
                return _csvFileName; 
            }
            set 
            {
                _csvFileName = value;
                OnPropertyChanged(nameof(CsvFileName));
            }
        }

        private EmployeeViewModel? _selectedToEdit;
        public EmployeeViewModel? SelectedToEdit 
        {
            get 
            {
                return _selectedToEdit;
            }
            set
            {
                _selectedToEdit = value; 
                OnPropertyChanged(nameof(SelectedToEdit));
            }
        }
        public ICommand? LoadCommand { get; }
        public ICommand? EditCommand { get;  }
        public ICommand? LoadUpdatedCommand { get; }

        public ManageCSVViewModel(EmployeeList employees, NavigationService editEmployeeNavigationService)
        {
            _employees = new ObservableCollection<EmployeeViewModel>();

            EditCommand = new EditCommand(this, editEmployeeNavigationService);
            LoadCommand = new LoadCSVCommand(this, employees);
            LoadUpdatedCommand = new LoadUpdatedCommand(this, employees);
        }
        public static ManageCSVViewModel LoadViewModel(EmployeeList employees, NavigationService editEmployeeNavigationService)
        {
            ManageCSVViewModel manageCSVViewModel = new ManageCSVViewModel(employees, editEmployeeNavigationService);

            if (manageCSVViewModel == null || manageCSVViewModel.LoadUpdatedCommand == null)
                throw new ArgumentNullException();

            manageCSVViewModel.LoadUpdatedCommand.Execute(null);

            return manageCSVViewModel;
        }
        public void UpdateEmployees(IEnumerable<Employee> employees, string filename)
        {
            _employees.Clear();
            CsvFileName = filename;
            foreach (var employee in employees)
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel(employee);
                _employees.Add(employeeViewModel);
            }
        }
        public void UpdateEmployees(IEnumerable<Employee> employees)
        {
            _employees.Clear();
            foreach (var employee in employees)
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel(employee);
                _employees.Add(employeeViewModel);
            }
        }
    }
}
