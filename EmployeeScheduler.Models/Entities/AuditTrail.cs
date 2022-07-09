using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeScheduler.Models.Entities;

public class AuditTrail
{
    [Key]
    public string AudiTrailID { get; set; }
    public string EntityType { get; set; }
    public string EntityID { get; set; }
    public string Action { get; set; }
    public DateTime AuditTrailDate { get; set; }
    public string Data { get; set; }

    public AuditTrail(string EntityType, string EntityID, string Action, string Data) 
    {
        this.EntityType = EntityType;
        this.EntityID = EntityID;
        this.Action = Action;
        this.Data = Data;
        this.AuditTrailDate = DateTime.Now;
    }
}
