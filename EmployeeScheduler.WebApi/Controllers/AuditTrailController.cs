using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Models.Entities;
using EmployeeScheduler.Models.Helpers;
using EmployeeScheduler.WebApi.Interfaces.AuditTrails;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeScheduler.WebApi.Controllers;

/// <summary>
/// AuditTrail Api Controller
/// Contains all the actions related to Audit Trail Entity
/// </summary>
public class AuditTrailController : BaseApiController
{
    private readonly IAuditTrailService _auditTrailService;

    public AuditTrailController(IAuditTrailService auditTrailService)
    {
        _auditTrailService = auditTrailService;
    }

    /// <summary>
    /// Action that retrieves Audit Trail records based on the filter parameters given 
    /// </summary>
    /// <remarks>
    /// Same request data:   
    /// 
    ///     Type: Employee | Skill
    ///     Action: CREATE | UPDATE | DELETE 
    ///     EntityID: EmployeeID or SkillID
    ///     
    /// </remarks>
    /// <param name="filterParams">Object parameter used for filtering the list of audit trails</param>
    /// <returns>List of audit trail records</returns>
    [HttpGet("GetAuditTrails")]
    public async Task<ActionResult<IEnumerable<AuditTrail>>> GetAuditTrails([FromQuery]AuditTrailFilterParams filterParams) 
    {
        try 
        {
            var auditTrailRecords = await _auditTrailService.GetAuditTrails(filterParams);

            return Ok(auditTrailRecords);
        }
        catch(Exception ex) 
        {
            return BadRequest(ex.Message);
        }
    }
}
