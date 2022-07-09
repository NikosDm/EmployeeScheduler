using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Models.Entities;

namespace EmployeeScheduler.WebApi.DTOs.Skills
{
    public class SkillDetailsDTO
    {
        public string SkillID { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [EnumDataType(typeof(SkillType))]
        public SkillType Type { get; set; }
    }
}