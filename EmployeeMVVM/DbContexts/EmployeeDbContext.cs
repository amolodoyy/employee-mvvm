using EmployeeMVVM.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVVM.DbContexts
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
