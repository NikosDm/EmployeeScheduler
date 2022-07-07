using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeScheduler.Models.Entities;
using EmployeeScheduler.WebApi.DTOs.Employees;
using EmployeeScheduler.WebApi.DTOs.Skills;

namespace EmployeeScheduler.WebApi.Helpers;

public class AutoMapperProfile
{
    public static MapperConfiguration RegisterAutoMapper()
    {
        return new MapperConfiguration(config => {
            config.CreateMap<EmployeeListDTO, Employee>(); 
            config.CreateMap<EmployeeDetailsDTO, Employee>(); 
            config.CreateMap<Employee, EmployeeListDTO>(); 
            config.CreateMap<Employee, EmployeeDetailsDTO>(); 
            
            config.CreateMap<SkillListDTO, Skill>(); 
            config.CreateMap<SkillDetailsDTO, Skill>(); 
            config.CreateMap<Skill, SkillListDTO>();
            config.CreateMap<Skill, SkillDetailsDTO>(); 
        });
    }
}
