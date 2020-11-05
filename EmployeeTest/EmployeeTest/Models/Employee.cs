using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTest.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName{ get; set; }
        public int HourlySalary { get; set; }
        public int MonthSalary { get; set; }
         
    }
}