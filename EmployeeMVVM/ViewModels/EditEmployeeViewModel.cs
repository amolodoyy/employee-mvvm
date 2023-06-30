using EmployeeMVVM.Commands;
using EmployeeMVVM.Models;
using EmployeeMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeMVVM.ViewModels
{
    public class EditEmployeeViewModel : ViewModelBase
    {
        private EmployeeViewModel _employee;
        public EmployeeViewModel EmployeeToEdit => _employee;

        private string? _name;
        public string? Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string? _surename;
        public string? Surename
        {
            get
            {
                return _surename;
            }
            set
            {
                _surename = value;
                OnPropertyChanged(nameof(Surename));
            }
        }
        private string? _email;
        public string? Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        private string? _phone;
        public string? Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        public ICommand SubmitEditionCommand { get; set; }
        public EditEmployeeViewModel(EmployeeViewModel employeeViewModel, NavigationService navigationService, EmployeeList employeeList)
        {
            SubmitEditionCommand = new SubmitEditionCommand(this, navigationService, employeeList);

            _employee = employeeViewModel;

            Name = _employee.Name;
            Surename = _employee.Surename;
            Email = _employee.Email;
            Phone = _employee.Phone;
        }

    }
}
