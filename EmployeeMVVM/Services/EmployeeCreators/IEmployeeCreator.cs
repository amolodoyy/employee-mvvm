using EmployeeMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMVVM.Services.EmployeeCreators
{
    public interface IEmployeeCreator
    {
        Task CreateEmployeeRange(List<Employee> employee);
    }
}
