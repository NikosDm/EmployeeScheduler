using System.ComponentModel.DataAnnotations;

namespace EmployeeScheduler.Models.Entities;

public class Employee
{
    [Key]
    public string EmployeeID { get; set; }   
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string JobTitle { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime HiringDate { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime UpdateDate { get; set; }
    public EmploymentType EmployeeType { get; set; }
    public ICollection<EmployeeSkill> Skills { get; set; }
}

public enum EmploymentType 
{
    FullTime = 1,
    PartTime = 2,
    Temporary = 3,
    Internship = 4
}

