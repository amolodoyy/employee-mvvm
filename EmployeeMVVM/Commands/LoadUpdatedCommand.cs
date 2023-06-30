using EmployeeMVVM.Models;
using EmployeeMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMVVM.Commands
{
    public class LoadUpdatedCommand : AsyncCommandBase
    {
        private readonly ManageCSVViewModel? _manageCSVViewModel;
        private readonly EmployeeList? _employees;
        public LoadUpdatedCommand(ManageCSVViewModel? manageCSVViewModel, EmployeeList? employees)
        {
            _manageCSVViewModel = manageCSVViewModel;
            _employees = employees;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            if (_employees == null)
                return;

            List<Employee> employee = (List<Employee>)await _employees.GetAllEmployees();
            _manageCSVViewModel?.UpdateEmployees(employee);
        }
    }
}
