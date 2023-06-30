using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMVVM.DbContexts
{
    public class EmployeeDbContextFactory
    {
        private readonly string _connectionString;

        public EmployeeDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public EmployeeDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new EmployeeDbContext(options);
        }
    }
}

