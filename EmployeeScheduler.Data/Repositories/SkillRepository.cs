using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Data.Database;
using EmployeeScheduler.Models.Entities;
using EmployeeScheduler.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeScheduler.Data.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly DataContext _dbContext;

    public SkillRepository(DataContext context)
    {
        _dbContext = context;
    }

    public async Task AddNewSkill(Skill skill)
    {
        await _dbContext.Skills.AddAsync(skill);
    }

    public async Task DeleteSkill(string SkillID)
    {
        var skill = await _dbContext.Skills.FirstOrDefaultAsync(s => s.SkillID == SkillID);

        _dbContext.Skills.Remove(skill);
    }

    public async Task<IEnumerable<Skill>> FetchAllSkills()
    {
        return await _dbContext.Skills.ToListAsync();
    }

    public async Task<Skill> FetchSkillDetails(string SkillID)
    {
        return await _dbContext.Skills.FirstOrDefaultAsync(s => s.SkillID == SkillID);
    }

    public async Task<Skill> UpdateSkill(Skill skill)
    {
        _dbContext.Skills.Update(skill);

        return await Task.FromResult(skill);
    }
}
