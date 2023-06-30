using EmployeeMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMVVM.Services.EmployeeEditors
{
    public interface IEmployeeEditor
    {
        Task EditEmployee(Employee employee);
    }
}
