using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeScheduler.Models.Entities
{
    public class Skill
    {
        public string SkillID { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string SKillCategoryID { get; set; }
        public SkillCategory Category { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}