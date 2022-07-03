using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Data.Database;
using EmployeeScheduler.Models.Entities;
using EmployeeScheduler.Models.Interfaces;

namespace EmployeeScheduler.Data.Data;
public class SkillRepository : ISkillRepository
{
    private readonly DataContext _context;

    public SkillRepository(DataContext context)
    {
        _context = context;
    }

    public Task<Skill> AddNewSkill()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteSkill()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Skill>> FetchAllSkills()
    {
        throw new NotImplementedException();
    }

    public Task<Skill> FetchSkillDetails()
    {
        throw new NotImplementedException();
    }

    public Task<Skill> UpdateSkill()
    {
        throw new NotImplementedException();
    }
}
