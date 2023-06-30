using EmployeeMVVM.DbContexts;
using EmployeeMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeMVVM.Services.EmployeeEditors
{
    public class DatabaseEmployeeEditor : IEmployeeEditor
    {
        private readonly EmployeeDbContextFactory _dbContextFactory;

        public DatabaseEmployeeEditor(EmployeeDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task EditEmployee(Employee employee)
        {
            using (EmployeeDbContext context = _dbContextFactory.CreateDbContext())
            {
                    Employee? employeeToEdit = context.Employees.Where(e => e.Id == employee.Id).FirstOrDefault();

                if (employeeToEdit != null)
                {
                    employeeToEdit.Name = employee.Name;
                    employeeToEdit.Surename = employee.Surename;
                    employeeToEdit.Email = employee.Email;
                    employeeToEdit.Phone = employee.Phone;
                }
                else
                    throw new ArgumentNullException(nameof(employee));
                
                await context.SaveChangesAsync();

            }
        }
    }
}
