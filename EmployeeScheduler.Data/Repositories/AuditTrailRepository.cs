using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Data.Database;
using EmployeeScheduler.Models.Entities;
using EmployeeScheduler.Models.Helpers;
using EmployeeScheduler.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeScheduler.Data.Repositories;

public class AuditTrailRepository : IAuditTrailRepository
{
    private readonly DataContext _dbContext;

    public AuditTrailRepository(DataContext context)
    {
        _dbContext = context;
    }

    public async Task AddNewAuditTrailRecord(AuditTrail auditTrail)
    {
        await _dbContext.AuditTrails.AddAsync(auditTrail);
    }

    public async Task<IEnumerable<AuditTrail>> GetAuditTrailRecords(AuditTrailFilterParams filterParams)
    {
        var query = _dbContext.AuditTrails.AsQueryable();

        query = query.Where(x => 
            (!string.IsNullOrWhiteSpace(filterParams.Type) ? x.EntityType.ToLower().Contains(filterParams.Type.ToLower()) : true) 
            && (!string.IsNullOrWhiteSpace(filterParams.Action) ? x.Action.ToLower().Contains(filterParams.Action.ToLower()) : true) 
            && (!string.IsNullOrWhiteSpace(filterParams.EntityID) ? x.EntityID.ToLower().Contains(filterParams.EntityID.ToLower()) : true));
        
        return await query.ToListAsync();
    }
}
