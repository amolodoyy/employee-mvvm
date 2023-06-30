using EmployeeMVVM.Models;
using EmployeeMVVM.Services;
using EmployeeMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMVVM.Commands
{
    public class SubmitEditionCommand : AsyncCommandBase
    {
        private readonly NavigationService _navigationService;
        private readonly EditEmployeeViewModel _editEmployeeViewModel;
        private readonly EmployeeList? _employees;
        public SubmitEditionCommand(EditEmployeeViewModel editEmployeeViewModel, NavigationService navigationService, EmployeeList employeeList) 
        { 
            _editEmployeeViewModel = editEmployeeViewModel;
            _navigationService = navigationService;
            _employees = employeeList;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            // save changes and exit

            Employee employee = new Employee(id: _editEmployeeViewModel.EmployeeToEdit.Id,
                name: _editEmployeeViewModel.Name,
                surename: _editEmployeeViewModel.Surename,
                email: _editEmployeeViewModel.Email,
                phone: _editEmployeeViewModel.Phone); 

            if(_employees == null)
                throw new ArgumentNullException();

            await _employees.EditEmployee(employee);

            _navigationService.Navigate();
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecutedChanged();
        }
    }
}
