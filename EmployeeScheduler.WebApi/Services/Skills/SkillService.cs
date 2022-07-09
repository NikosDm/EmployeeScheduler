using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeScheduler.Models.Entities;
using EmployeeScheduler.Models.Interfaces;
using EmployeeScheduler.WebApi.DTOs.Skills;
using EmployeeScheduler.WebApi.Interfaces.Skills;

namespace EmployeeScheduler.WebApi.Services.Skills;

public class SkillService : ISkillService
{
    private readonly IUnitOfWork _unitOfWork;
    
    private readonly IMapper _mapper;

    public SkillService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    public async Task<bool> AddNewSkill(SkillDetailsDTO skillDetailsDTO)
    {
        var skill = _mapper.Map<Skill>(skillDetailsDTO);

        await _unitOfWork.skillRepository.AddNewSkill(skill);

        if (_unitOfWork.HasChanges()) return await _unitOfWork.Complete();

        return false;
    }

    public async Task<bool> DeleteSkill(string SkillID)
    {
        await _unitOfWork.skillRepository.DeleteSkill(SkillID);
        
        if (_unitOfWork.HasChanges()) return await _unitOfWork.Complete();

        return false;
    }

    public async Task<IEnumerable<SkillListDTO>> FetchAllSkills()
    {
        var skills = await _unitOfWork.skillRepository.FetchAllSkills();

        return _mapper.Map<IEnumerable<SkillListDTO>>(skills);
    }

    public async Task<SkillDetailsDTO> FetchSkillByID(string SkillID)
    {
        var skill = await GetSkill(SkillID);

        return _mapper.Map<SkillDetailsDTO>(skill);
    }

    public async Task<SkillDetailsDTO> UpdateSkill(SkillDetailsDTO skillDetailsDTO)
    {
        var skill = await GetSkill(skillDetailsDTO.SkillID);

        skill.Title = skillDetailsDTO.Title;
        skill.Description = skillDetailsDTO.Description;
        skill.Type = skillDetailsDTO.Type;

        skill = await _unitOfWork.skillRepository.UpdateSkill(skill);
        
        if (_unitOfWork.HasChanges()) await _unitOfWork.Complete();

        return _mapper.Map<SkillDetailsDTO>(skill);
    }
    
    private async Task<Skill> GetSkill(string SkillID)
    {
        var skill = await _unitOfWork.skillRepository.FetchSkillDetails(SkillID);

        if (skill == null) throw new Exception("Skill does not exist");

        return skill;
    }
}

