using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.WebApi.DTOs.Skills;

namespace EmployeeScheduler.WebApi.Interfaces.Skills;

public interface ISkillService
{
    Task<IEnumerable<SkillListDTO>> FetchAllSkills();
    Task<SkillDetailsDTO> FetchSkillByID(string SkillID);
    Task<bool> AddNewSkill(SkillDetailsDTO skillDetailsDTO);
    Task<SkillDetailsDTO> UpdateSkill(SkillDetailsDTO skillDetailsDTO);
    Task<bool> DeleteSkill(string SkillID);
}

