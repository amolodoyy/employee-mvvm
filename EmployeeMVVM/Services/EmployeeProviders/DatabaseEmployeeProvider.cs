using EmployeeMVVM.DbContexts;
using EmployeeMVVM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeMVVM.Services.EmployeeProviders
{
    public class DatabaseEmployeeProvider : IEmployeeProvider
    {
        private EmployeeDbContextFactory _dbContextFactory;

        public DatabaseEmployeeProvider(EmployeeDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            using(EmployeeDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<Employee> employees = await context.Employees.ToListAsync();
                return employees;
            }
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            using(EmployeeDbContext context = _dbContextFactory.CreateDbContext())
            {
                var employee = await context.Employees.Where(e => e.Id == id).FirstOrDefaultAsync();

                return employee ?? throw new ArgumentNullException(nameof(employee));
            }
        }
    }
}
