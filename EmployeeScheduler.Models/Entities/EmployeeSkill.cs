using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeScheduler.Models.Entities
{
    public class EmployeeSkill
    {
        public Employee Employee { get; set; }
        public string EmployeeID { get; set; }
        public Skill Skill { get; set; }
        public string SkillID { get; set; }
    }
}