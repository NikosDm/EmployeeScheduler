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
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public EmploymentType EmployeeType { get; set; }
    public ICollection<EmployeeSkill> Skills { get; set; }

    public void updateValues(string FirstName, 
        string LastName, string Email, 
        string JobTitle, DateTime HiringDate, 
        EmploymentType employmentType, DateTime DateOfBirth) 
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Email = Email;
        this.JobTitle = JobTitle;
        this.HiringDate = HiringDate;
        this.DateOfBirth = DateOfBirth;
        this.EmployeeType = employmentType;
    }
}

public enum EmploymentType 
{
    FullTime = 1,
    PartTime = 2,
    Temporary = 3,
    Internship = 4
}

