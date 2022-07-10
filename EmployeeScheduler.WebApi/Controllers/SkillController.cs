using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using EmployeeScheduler.WebApi.Interfaces.Skills;
using EmployeeScheduler.WebApi.DTOs.Skills;
using ClosedXML.Excel;

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
    /// <remarks>
    /// Same request data  
    /// {
    ///    "title": "New Skill Title",
    ///    "description": "Details about new skill",
    ///    "type": 1
    /// }
    /// </remarks>
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
    /// <remarks>
    /// Same request data  
    /// {
    ///    "skillID": "SKILL_ID",
    ///    "title": "New Skill Title",
    ///    "description": "Details about new skill",
    ///    "type": 1
    /// }
    /// </remarks>
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
    
    /// <summary>
    /// Action that exports all the available skills on Excel file
    /// </summary>
    /// <returns>An excel file</returns>
    [HttpGet("ExportSkillsToExcel")]
    public async Task<IActionResult> ExportSkillsToExcel() 
    {
        try 
        {
            var skills = await _skillService.FetchAllSkillsForExport();

            using var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("Skills");

            int currentRow = 1;
            worksheet.Cell(currentRow, 1).Value = "Skill ID";
            worksheet.Cell(currentRow, 2).Value = "Title";
            worksheet.Cell(currentRow, 3).Value = "Description";
            worksheet.Cell(currentRow, 4).Value = "Type";
            worksheet.Cell(currentRow, 5).Value = "Created";
            worksheet.Cell(currentRow, 6).Value = "Last Update";

            foreach (var skill in skills) 
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = skill.SkillID;
                worksheet.Cell(currentRow, 2).Value = skill.Title;
                worksheet.Cell(currentRow, 3).Value = skill.Description;
                worksheet.Cell(currentRow, 4).Value = skill.Type;
                worksheet.Cell(currentRow, 5).Value = skill.CreatedAt;
                worksheet.Cell(currentRow, 6).Value = skill.LastUpdateAt;
            }

            using var stream = new MemoryStream();

            workbook.SaveAs(stream);
            var content = stream.ToArray();
        
            string excelName = string.Format("CurrentSkills_{0}.xlsx", DateTime.Now.ToString("yyyyMMddHHmmss"));
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheet.sheet", excelName);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
