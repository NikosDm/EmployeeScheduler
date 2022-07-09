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

    public void updateSkills(IEnumerable<EmployeeSkill> skills)
    {
        this.Skills = new List<EmployeeSkill>();
        
        foreach (var skill in skills) 
        {
            if (!string.IsNullOrWhiteSpace(skill.SkillID) && this.Skills.Any(x => x.SkillID == skill.SkillID))
                continue;
            else if (!string.IsNullOrWhiteSpace(skill.SkillID) && !this.Skills.Any(x => x.SkillID == skill.SkillID))
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
}

public enum EmploymentType 
{
    FullTime = 1,
    PartTime = 2,
    Temporary = 3,
    Internship = 4
}

