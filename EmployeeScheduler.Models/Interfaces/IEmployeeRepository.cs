using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Models.Entities;
using EmployeeScheduler.Models.Helpers;

namespace EmployeeScheduler.Models.Interfaces;
public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> FetchEmployees(FilterParams filterParams);
    Task<Employee> FetchEmployeeDetails(string EmployeeID);
    Task AddNewEmployee(Employee employee);
    Task<Employee> UpdateEmployee(Employee employee);
    Task DeleteEmployees(ICollection<Employee> employees);
    Task<ICollection<Employee>> FetchEmployeesByIds(ICollection<string> employeeIDs);
}
