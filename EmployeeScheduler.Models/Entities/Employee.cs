using System.ComponentModel.DataAnnotations;
using EmployeeScheduler.Models.Validations;

namespace EmployeeScheduler.Models.Entities;

public class Employee
{
    [Key]
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
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    
    [Required]
    [EnumDataType(typeof(EmploymentType))]
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

    public void updateSkills(IEnumerable<EmployeeSkill> skills)
    {
        this.Skills = new List<EmployeeSkill>();
        
        foreach (var skill in skills) 
        {
            if (!string.IsNullOrWhiteSpace(skill.SkillID) && !this.Skills.Any(x => x.SkillID == skill.SkillID))
                this.Skills.Add(new EmployeeSkill { SkillID = skill.SkillID, EmployeeID = this.EmployeeID });
            else 
                if (skill != null && skill.Skill != null)
                    this.Skills.Add(new EmployeeSkill { SkillID = null, 
                        EmployeeID = this.EmployeeID, 
                        Skill = new Skill { 
                            Title = skill?.Skill?.Title,
                            Description = skill?.Skill?.Description, 
                            Type = skill.Skill.Type, 
                        } });
                else 
                    continue;
        }
    }

    public override string ToString()
    {
        string skills = string.Empty;

        if (this.Skills.Any()) 
            skills = string.Join(", ", this.Skills.Select(x => x.Skill?.Title).ToArray());
        else 
            skills = "NO SKILLS";

        return string.Format("Employee: {0} {1}, With Email Address: {2}, Born on the: {3} Title: {4}, Employment Type: {5}, Hired on the: {6} with the following skills: {7}", this.FirstName, this.LastName, this.Email, this.DateOfBirth.ToString("d"), this.JobTitle, this.EmployeeType.ToString(), this.DateOfBirth.ToString("d"), skills);    
    }
}

public enum EmploymentType 
{
    FullTime = 1,
    PartTime = 2,
    Temporary = 3,
    Internship = 4
}

