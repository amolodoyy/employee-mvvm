using EmployeeMVVM.Services.EmployeeCreators;
using EmployeeMVVM.Services.EmployeeEditors;
using EmployeeMVVM.Services.EmployeeProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMVVM.Models
{
    public class EmployeeList
    {
        private readonly IEmployeeCreator _employeeCreator;
        private readonly IEmployeeEditor _employeeEditor;
        private readonly IEmployeeProvider _employeeProvider;

        public EmployeeList(IEmployeeCreator employeeCreator, IEmployeeEditor employeeEditor, IEmployeeProvider employeeProvider)
        {
            _employeeCreator = employeeCreator;
            _employeeEditor = employeeEditor;
            _employeeProvider = employeeProvider;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _employeeProvider.GetAllEmployees();
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeProvider.GetEmployeeById(id);
        }
        public async Task CreateEmployeeRange(List<Employee> employees)
        {
            await _employeeCreator.CreateEmployeeRange(employees);
        }

        public async Task EditEmployee(Employee employee)
        {
            await _employeeEditor.EditEmployee(employee);
        }
    }
}
