using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Models.Entities;

namespace EmployeeScheduler.WebApi.DTOs.Skills
{
    public class SkillDetailsDTO
    {
        public string SkillID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; }
        public SkillType Type { get; set; }
    }
}