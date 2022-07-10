using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Models.Entities;

namespace EmployeeScheduler.Models.Interfaces;

public interface ISkillRepository
{
    Task<IEnumerable<Skill>> FetchAllSkills();
    Task<Skill> FetchSkillDetails(string SkillID);
    Task AddNewSkill(Skill skill);
    Task<Skill> UpdateSkill(Skill skill);
    Task DeleteSkill(Skill skill);
}
