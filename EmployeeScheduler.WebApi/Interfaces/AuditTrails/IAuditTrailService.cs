using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Models.Entities;
using EmployeeScheduler.Models.Helpers;

namespace EmployeeScheduler.WebApi.Interfaces.AuditTrails;

public interface IAuditTrailService
{
    Task<IEnumerable<AuditTrail>> GetAuditTrails(AuditTrailFilterParams filterParams);
}