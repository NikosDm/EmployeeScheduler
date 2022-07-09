using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeScheduler.Models.Entities;

public class Skill
{
    [Key]
    public string SkillID { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    
    [Required]
    [EnumDataType(typeof(SkillType))]
    public SkillType Type { get; set; }
    public ICollection<EmployeeSkill> EmployeeSkills { get; set; }

    public override string ToString()
    {
        return string.Format("Skill: {0}, of type: {1}, Details: {2}", this.Title, this.Type.ToString(), this.Description);
    }

    public string GetTypeDescription()
    {
        switch (this.Type) 
        {
            case SkillType.SoftSkill: 
                return "Soft skill";
            case SkillType.TechnicalSkill: 
                return "Technical skill";
            case SkillType.LeadershipSkill: 
                return "Leadership skill";
            default: 
                return string.Empty;
        }
    }
}

public enum SkillType 
{
    SoftSkill = 1,
    TechnicalSkill = 2,
    LeadershipSkill = 3
}
