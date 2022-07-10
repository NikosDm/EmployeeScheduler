using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeScheduler.Models.Helpers;

public class AuditTrailFilterParams
{
    public string Type { get; set; }
    public string Action { get; set; }
    public string EntityID { get; set; }
}
