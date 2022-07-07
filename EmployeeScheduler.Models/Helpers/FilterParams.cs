using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeScheduler.Models.Helpers;

public class FilterParams
{
    public string SearchValue { get; set; }
    public string SortDirection { get; set; }
    public string SortColumn { get; set; }
}