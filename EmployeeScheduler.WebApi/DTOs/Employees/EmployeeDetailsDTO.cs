using System.ComponentModel.DataAnnotations;
using EmployeeScheduler.Models.Entities;
using EmployeeScheduler.Models.Validations;

namespace EmployeeScheduler.WebApi.DTOs.Employees;

public class EmployeeDetailsDTO
{
    public string EmployeeID { get; set; }   

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
    
    [Required]
    public string JobTitle { get; set; }
    
    [Required]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [DateEarlierThan("HiringDate", ErrorMessage = "Date of birth should not be later than Hiring date")]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    public DateTime HiringDate { get; set; }
    
    [Required]
    [EnumDataType(typeof(EmploymentType))]
    public EmploymentType EmployeeType { get; set; }
    public ICollection<EmployeeSkill> Skills { get; set; }
}
