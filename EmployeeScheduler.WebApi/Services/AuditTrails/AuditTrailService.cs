using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Models.Entities;
using EmployeeScheduler.Models.Helpers;
using EmployeeScheduler.Models.Interfaces;
using EmployeeScheduler.WebApi.Interfaces.AuditTrails;

namespace EmployeeScheduler.WebApi.Services.AuditTrails;

public class AuditTrailService : IAuditTrailService
{
    private readonly IUnitOfWork _unitOfWork;

    public AuditTrailService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<AuditTrail>> GetAuditTrails(AuditTrailFilterParams filterParams)
    {
        return await _unitOfWork.auditTrailRepository.GetAuditTrailRecords(filterParams);
    }
}
