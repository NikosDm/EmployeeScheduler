using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeScheduler.WebApi.DTOs.Employees
{
    public class EmployeeListDTO
    {
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HiringDate { get; set; }
        public string JobTitle { get; set; }
    }
}