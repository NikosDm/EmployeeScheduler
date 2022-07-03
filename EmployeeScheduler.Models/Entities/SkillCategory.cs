using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeScheduler.Models.Entities
{
    public class SkillCategory
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string SkillID { get; set; }
        public Skill Skill { get; set; }
    }
}