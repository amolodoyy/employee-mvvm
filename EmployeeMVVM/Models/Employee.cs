using EmployeeMVVM.Services.EmployeeCreators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMVVM.Models
{
    public class Employee
    {
        
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surename { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }


        public Employee(int id, string? name, string? surename, string? email, string? phone)
        {
            Id = id;
            Name = name;
            Surename = surename;
            Email = email;
            Phone = phone;
        }

    }
}
