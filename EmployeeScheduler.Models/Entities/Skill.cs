using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeScheduler.Models.Entities
{
    public class Skill
    {
        [Key]
        public string SkillID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; }
        public SkillType Type { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }

    public enum SkillType 
    {
        SoftSkill = 1,
        TechnicalSkill = 2,
        LeadershipSkill = 3
    }

}