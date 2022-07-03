using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeScheduler.Models.Interfaces;
public interface IUnitOfWork
{
    IEmployeeRepository employeeRepository { get; }
    ISkillRepository skillRepository { get; }
    Task<bool> Complete();
    bool HasChanges();
}
