using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Models.Helpers;
using EmployeeScheduler.WebApi.DTOs.Employees;

namespace EmployeeScheduler.WebApi.Employees.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeListDTO>> FetchAllEmployees(FilterParams filterParams);
    Task<EmployeeDetailsDTO> FetchEmployeeByID(string EmployeeID);
    Task<bool> AddNewEmployee(EmployeeDetailsDTO employeeDetailsDTO);
    Task<EmployeeDetailsDTO> UpdateEmployee(EmployeeDetailsDTO employeeDetailsDTO);
    Task<bool> DeleteEmployees(IEnumerable<string> employeeIDs);
}
