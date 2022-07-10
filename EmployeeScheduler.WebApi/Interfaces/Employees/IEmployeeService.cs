using EmployeeScheduler.Models.Helpers;
using EmployeeScheduler.WebApi.DTOs.Employees;

namespace EmployeeScheduler.WebApi.Interfaces.Employees;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeListDTO>> FetchAllEmployees(FilterParams filterParams);
    Task<EmployeeDetailsDTO> FetchEmployeeByID(string EmployeeID);
    Task<bool> AddNewEmployee(EmployeeDetailsDTO employeeDetailsDTO);
    Task<EmployeeDetailsDTO> UpdateEmployee(EmployeeDetailsDTO employeeDetailsDTO);
    Task<bool> DeleteEmployees(ICollection<string> employeeIDs);
}
