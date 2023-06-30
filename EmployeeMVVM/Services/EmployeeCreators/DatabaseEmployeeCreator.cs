using EmployeeMVVM.DbContexts;
using EmployeeMVVM.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace EmployeeMVVM.Services.EmployeeCreators
{
    public class DatabaseEmployeeCreator : IEmployeeCreator
    {
        private readonly EmployeeDbContextFactory _dbContextFactory;

        public DatabaseEmployeeCreator(EmployeeDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateEmployeeRange(List<Employee> employeeList)
        {
            using(EmployeeDbContext context = _dbContextFactory.CreateDbContext())
            {
                context.AddRange(employeeList);
                await context.SaveChangesAsync();
            }
        }
    }
}
