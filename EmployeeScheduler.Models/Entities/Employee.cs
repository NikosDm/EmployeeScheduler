using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
    public EmploymentType EmployeeType { get; set; }
    public ICollection<EmployeeSkill> Skills { get; set; }
}

public enum EmploymentType 
{
    FullTime = 1,
    PartTime = 2,
    Seasonal = 3,
    Temporary = 4,
    Internship = 5
}

