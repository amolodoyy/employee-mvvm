using EmployeeMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMVVM.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        private readonly Employee _employee;
        public int Id => _employee.Id;
        public string? Name => _employee.Name;
        public string? Surename => _employee.Surename;
        public string? Email => _employee.Email;
        public string? Phone => _employee.Phone;
        public EmployeeViewModel(Employee employee)
        {
            _employee = employee;
        }
    }
}
