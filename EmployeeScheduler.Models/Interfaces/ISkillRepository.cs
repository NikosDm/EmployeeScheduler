using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Models.Entities;

namespace EmployeeScheduler.Models.Interfaces;

public interface ISkillRepository
{
    Task<IEnumerable<Skill>> FetchAllSkills();
    Task<Skill> FetchSkillDetails();
    Task<Skill> AddNewSkill();
    Task<Skill> UpdateSkill();
    Task<bool> DeleteSkill();
}
