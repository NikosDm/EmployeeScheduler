using EmployeeScheduler.Models.Entities;

namespace EmployeeScheduler.WebApi.DTOs.Employees;

public class EmployeeDetailsDTO
{
    public string EmployeeID { get; set; }   
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string JobTitle { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime HiringDate { get; set; }
    public EmploymentType EmployeeType { get; set; }
    public ICollection<EmployeeSkill> Skills { get; set; }
}
