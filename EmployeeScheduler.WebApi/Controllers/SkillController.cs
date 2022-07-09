using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.WebApi.DTOs;
using EmployeeScheduler.Models.Helpers;
using EmployeeScheduler.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EmployeeScheduler.WebApi.Interfaces.Skills;
using EmployeeScheduler.WebApi.DTOs.Skills;

namespace EmployeeScheduler.WebApi.Controllers;

/// <summary>
/// Skill Api Controller
/// Contains all the actions related to Employee Entity
/// </summary>
/// <returns>Every action returns an instance of ResponseDTO class which contains data or any exception that may occur</returns>
public class SkillController : BaseApiController
{
    private readonly ISkillService _skillService;
    protected ResponseDTO _response; 

    public SkillController(ISkillService skillService) 
    {
        _skillService = skillService;
        _response = new ResponseDTO();
    }
    
    /// <summary>
    /// Returns the list of all the available skills
    /// </summary>
    [HttpGet("GetAllSkills")]
    public async Task<ActionResult<ResponseDTO>> GetAllSkills() 
    {
        try 
        {
            _response.Result = await _skillService.FetchAllSkills();
            _response.Message = "Success";
        }
        catch(Exception ex) 
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return this._response;
    }
    
    /// <summary>
    /// Action that retrieves a specific Skill but its ID
    /// </summary>
    /// <param name="SkillID">Id of the skill</param>
    [HttpGet("GetSkill/{SkillID}")]
    public async Task<ActionResult<ResponseDTO>> GetSkill(string SkillID) 
    {
        try 
        {
            _response.Result = await _skillService.FetchSkillByID(SkillID);
            _response.Message = "Success";
        }
        catch(Exception ex) 
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return this._response;
    }
    
    /// <summary>
    /// Action that adds a new Skill
    /// </summary>
    /// <param name="skillDetailsDTO">Object parameter that contains all the information regarding the new skill</param>
    [HttpPost("AddNewSkill")]
    public async Task<ActionResult<ResponseDTO>> AddNewSkill([FromBody]SkillDetailsDTO skillDetailsDTO) 
    {
        try 
        {
            var result = await _skillService.AddNewSkill(skillDetailsDTO);

            if (!result) throw new Exception("New skill could not be added");

            _response.Result = result;
            _response.Message = "Success";
        }
        catch(Exception ex) 
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }

    /// <summary>
    /// Action that updates the information of an existing skill
    /// </summary>
    /// <param name="skillDetailsDTO">Object parameter that contains all the updated information regarding the existing skill</param>
    [HttpPut("UpdateSkill")]
    public async Task<ResponseDTO> UpdateSkill([FromBody]SkillDetailsDTO skillDetailsDTO) 
    {
        try 
        {
            var skill =  await _skillService.UpdateSkill(skillDetailsDTO);
            _response.Result = skill;
            _response.Message = "Success";
        }
        catch(Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }
    
    /// <summary>
    /// Action that deletes a skill
    /// </summary>
    /// <param name="skillID">ID of skill</param>
    [HttpDelete("DeleteSkill/{skillID}")]
    public async Task<ResponseDTO> DeleteSkill(string skillID) 
    {
        try 
        {
            var result =  await _skillService.DeleteSkill(skillID);

            if (!result) throw new Exception("Skill could not be deleted");

            _response.Message = "Success";
        }
        catch(Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }
}
