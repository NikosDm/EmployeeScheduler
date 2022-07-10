using EmployeeScheduler.Models.Entities;
using EmployeeScheduler.Models.Helpers;

namespace EmployeeScheduler.Models.Interfaces;

public interface IAuditTrailRepository
{
    Task<IEnumerable<AuditTrail>> GetAuditTrailRecords(AuditTrailFilterParams filterParams);
    Task AddNewAuditTrailRecord(AuditTrail auditTrail);
}

