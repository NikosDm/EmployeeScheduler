using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Models.Entities;

namespace EmployeeScheduler.Models.Interfaces;
public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> FetchEmployees();
    Task<Employee> FetchEmployeeDetails();
    Task<Employee> AddNewEmployee();
    Task<Employee> UpdateEmployee();
    Task<bool> DeleteEmployee();
}
