using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Models.Entities;

namespace EmployeeScheduler.WebApi.DTOs.Skills;

public class SkillExcelListDTO
{
    public string SkillID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CreatedAt { get; set; }
    public string LastUpdateAt { get; set; }
    public string Type { get; set; }
}
