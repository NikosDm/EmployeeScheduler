using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Data.Database;
using EmployeeScheduler.Models.Entities;

namespace EmployeeScheduler.WebApi.Data;

public class Seed
{
    /*The application is filled with data for testing purposes*/
    public static async Task SeedData(DataContext dataContext) 
    {
        var skills = new List<Skill>() 
        {
            new Skill() { Title = "Web development", 
            Description = "The abilitiy to develop web application using various web technologies such as HTML, CSS and Javascript",
            Type = SkillType.TechnicalSkill },
            new Skill() { Title = "Microsoft Office", 
            Description = "The abilitiy to with microsoft office tools like Excel and Power point",
            Type = SkillType.TechnicalSkill },
            new Skill() { Title = "Database management", 
            Description = "Working either with relation or non relational database for managing applications data",
            Type = SkillType.TechnicalSkill },
            new Skill() { Title = "Technical support", 
            Description = "Resolve technical problems regarding computer or any other technical operations",
            Type = SkillType.TechnicalSkill },
            new Skill() { Title = "Backend development", 
            Description = "The abilitiy to develop server side application using various technologies such as .NET or Java technologies",
            Type = SkillType.TechnicalSkill },
            new Skill() { Title = "Basic computer skills", 
            Description = "Basic knowledge of using a computer",
            Type = SkillType.TechnicalSkill },
            new Skill() { Title = "Operating system", 
            Description = "Knowledge of a specific operating system like Windows or Linux",
            Type = SkillType.TechnicalSkill }, //6

            new Skill() { Title = "Communication skills", 
            Description = "Listen and say information clearly when you speak or write",
            Type = SkillType.SoftSkill },
            new Skill() { Title = "Teamwork", 
            Description = "Collaborate with other people in order to achieve some goals",
            Type = SkillType.SoftSkill },
            new Skill() { Title = "Motivation", 
            Description = "Willingness to acquire new skills, improve current ones and perform as better as possible during work",
            Type = SkillType.SoftSkill },
            new Skill() { Title = "Self-management", 
            Description = "The ability to manage personal work and time",
            Type = SkillType.SoftSkill },
            new Skill() { Title = "Time management", 
            Description = "Managing time, prioritizing tasks and meeting deadlines",
            Type = SkillType.SoftSkill },
            new Skill() { Title = "Foreign language speaker", 
            Description = "Knowledge of communicating on foreign languages",
            Type = SkillType.SoftSkill },
            new Skill() { Title = "Openess to feeback", 
            Description = "Open to receive either positive or negative feedback",
            Type = SkillType.SoftSkill }, // 13

            new Skill() { Title = "Team leadership", 
            Description = "Being responsible of a group of people",
            Type = SkillType.LeadershipSkill },
            new Skill() { Title = "Project planning", 
            Description = "Plan all the phases of a project from implementation to delivery in terms of time and workforce",
            Type = SkillType.LeadershipSkill },
            new Skill() { Title = "Recruiting skills", 
            Description = "Determine whether a candidate is suitable for joining the team or not",
            Type = SkillType.LeadershipSkill },
            new Skill() { Title = "Building trust", 
            Description = "Be a trustworthy and reliable leader",
            Type = SkillType.LeadershipSkill },
            new Skill() { Title = "Assess employees' skills", 
            Description = "Discover employees' weaknesses and strengths",
            Type = SkillType.LeadershipSkill },
            new Skill() { Title = "Motivate employees", 
            Description = "Make employees perform better and grow as professionals",
            Type = SkillType.LeadershipSkill },
            new Skill() { Title = "Empathy", 
            Description = "Understand employees' problems and give them advice on how to solve them",
            Type = SkillType.LeadershipSkill }, // 20

            new Skill() { Title = "Advanced computer skills", 
            Description = "Advanced skills of using a computer",
            Type = SkillType.TechnicalSkill },
        };

        var Employees = new List<Employee>() {
            new Employee { FirstName = "Nick", LastName = "Thomas", DateOfBirth = new DateTime(1993, 2, 2), 
                JobTitle = "Web developer", HiringDate = new DateTime(2022, 2, 2), EmployeeType = EmploymentType.FullTime, 
                Email = "nthomas@dummy.com", Skills = new List<EmployeeSkill> { 
                    new EmployeeSkill { Skill = skills[0] }, 
                    new EmployeeSkill { Skill = skills[1] }, 
                    new EmployeeSkill { Skill = skills[5] }, 
                    new EmployeeSkill { Skill = skills[6] }, 
                    new EmployeeSkill { Skill = skills[8] }, 
                    new EmployeeSkill { Skill = skills[9] }, 
                }
            },
            new Employee { FirstName = "Scott", LastName = "Ian", DateOfBirth = new DateTime(1993, 6, 2), 
                JobTitle = "Backend developer", HiringDate = new DateTime(2021, 10, 2), EmployeeType = EmploymentType.FullTime, 
                Email = "sian@dummy.com", Skills = new List<EmployeeSkill> { 
                    new EmployeeSkill { Skill = skills[4] }, 
                    new EmployeeSkill { Skill = skills[1] }, 
                    new EmployeeSkill { Skill = skills[5] }, 
                    new EmployeeSkill { Skill = skills[6] }, 
                    new EmployeeSkill { Skill = skills[8] }, 
                    new EmployeeSkill { Skill = skills[9] }, 
                }
            },
            new Employee { FirstName = "George", LastName = "Larson", DateOfBirth = new DateTime(1993, 2, 10), 
                JobTitle = "Full stack developer", HiringDate = new DateTime(2021, 11, 2), EmployeeType = EmploymentType.FullTime, 
                Email = "glarson@dummy.com", Skills = new List<EmployeeSkill> { 
                    new EmployeeSkill { Skill = skills[0] }, 
                    new EmployeeSkill { Skill = skills[1] },
                    new EmployeeSkill { Skill = skills[2] }, 
                    new EmployeeSkill { Skill = skills[4] },  
                    new EmployeeSkill { Skill = skills[5] }, 
                    new EmployeeSkill { Skill = skills[6] }, 
                    new EmployeeSkill { Skill = skills[8] }, 
                    new EmployeeSkill { Skill = skills[9] }, 
                }
            },
            new Employee { FirstName = "John", LastName = "Stevenson", DateOfBirth = new DateTime(1993, 5, 10), 
                JobTitle = "Database developer", HiringDate = new DateTime(2020, 11, 2), EmployeeType = EmploymentType.FullTime, 
                Email = "jstevenson@dummy.com", Skills = new List<EmployeeSkill> {  
                    new EmployeeSkill { Skill = skills[1] },
                    new EmployeeSkill { Skill = skills[2] },  
                    new EmployeeSkill { Skill = skills[5] }, 
                    new EmployeeSkill { Skill = skills[6] }, 
                    new EmployeeSkill { Skill = skills[8] }, 
                    new EmployeeSkill { Skill = skills[9] }, 
                }
            },
            new Employee { FirstName = "Michael", LastName = "Muller", DateOfBirth = new DateTime(2000, 7, 10), 
                JobTitle = "Junior Web Developer", HiringDate = new DateTime(2022, 6, 2), EmployeeType = EmploymentType.Internship, 
                Email = "mmuller@dummy.com", Skills = new List<EmployeeSkill> {  
                    new EmployeeSkill { Skill = skills[0] }, 
                    new EmployeeSkill { Skill = skills[1] }, 
                    new EmployeeSkill { Skill = skills[5] }, 
                    new EmployeeSkill { Skill = skills[6] }, 
                    new EmployeeSkill { Skill = skills[8] }, 
                    new EmployeeSkill { Skill = skills[9] }, 
                }
            },
            new Employee { FirstName = "Nick", LastName = "Scott", DateOfBirth = new DateTime(2000, 7, 10), 
                JobTitle = "QA engineer", HiringDate = new DateTime(2022, 6, 2), EmployeeType = EmploymentType.PartTime, 
                Email = "nscott@dummy.com", Skills = new List<EmployeeSkill> {  
                    new EmployeeSkill { Skill = skills[0] }, 
                    new EmployeeSkill { Skill = skills[1] },
                    new EmployeeSkill { Skill = skills[2] }, 
                    new EmployeeSkill { Skill = skills[4] },  
                    new EmployeeSkill { Skill = skills[5] }, 
                    new EmployeeSkill { Skill = skills[6] }, 
                    new EmployeeSkill { Skill = skills[8] }, 
                    new EmployeeSkill { Skill = skills[9] }, 
                }
            },
            new Employee { FirstName = "Selina", LastName = "Turner", DateOfBirth = new DateTime(1990, 1, 10), 
                JobTitle = "Team Leader of Development team", HiringDate = new DateTime(2016, 6, 2), EmployeeType = EmploymentType.FullTime, 
                Email = "sturner@dummy.com", Skills = new List<EmployeeSkill> {  
                    new EmployeeSkill { Skill = skills[0] }, 
                    new EmployeeSkill { Skill = skills[1] },
                    new EmployeeSkill { Skill = skills[2] }, 
                    new EmployeeSkill { Skill = skills[4] },  
                    new EmployeeSkill { Skill = skills[5] }, 
                    new EmployeeSkill { Skill = skills[6] }, 
                    new EmployeeSkill { Skill = skills[8] }, 
                    new EmployeeSkill { Skill = skills[9] }, 
                    
                    new EmployeeSkill { Skill = skills[14] }, 
                    new EmployeeSkill { Skill = skills[15] },
                    new EmployeeSkill { Skill = skills[16] }, 
                    new EmployeeSkill { Skill = skills[17] },  
                    new EmployeeSkill { Skill = skills[18] }, 
                    new EmployeeSkill { Skill = skills[19] }, 
                    new EmployeeSkill { Skill = skills[20] },
                }
            },
            new Employee { FirstName = "Gina", LastName = "Meriot", DateOfBirth = new DateTime(1997, 4, 25), 
                JobTitle = "Accountant", HiringDate = new DateTime(2018, 6, 2), EmployeeType = EmploymentType.FullTime, 
                Email = "gmeriot@dummy.com", Skills = new List<EmployeeSkill> {   
                    new EmployeeSkill { Skill = skills[1] },
                    new EmployeeSkill { Skill = skills[5] }, 
                    new EmployeeSkill { Skill = skills[6] }, 
                    new EmployeeSkill { Skill = skills[7] }, 
                    new EmployeeSkill { Skill = skills[12] }, 
                }
            },
            new Employee { FirstName = "Maria", LastName = "Tron", DateOfBirth = new DateTime(1989, 6, 25), 
                JobTitle = "Product Manager", HiringDate = new DateTime(2018, 6, 2), EmployeeType = EmploymentType.FullTime, 
                Email = "mtron@dummy.com", Skills = new List<EmployeeSkill> {   
                    new EmployeeSkill { Skill = skills[14] },
                    new EmployeeSkill { Skill = skills[15] }, 
                    new EmployeeSkill { Skill = skills[16] }, 
                    new EmployeeSkill { Skill = skills[17] }, 
                    new EmployeeSkill { Skill = skills[18] }, 
                    new EmployeeSkill { Skill = skills[19] }, 
                    new EmployeeSkill { Skill = skills[20] }, 
                }
            },
            new Employee { FirstName = "Brianna", LastName = "Shamalt", DateOfBirth = new DateTime(1992, 1, 25), 
                JobTitle = "IT Support Administrator", HiringDate = new DateTime(2017, 6, 2), EmployeeType = EmploymentType.PartTime, 
                Email = "bshamalt@dummy.com", Skills = new List<EmployeeSkill> {   
                    new EmployeeSkill { Skill = skills[21] },
                    new EmployeeSkill { Skill = skills[6] }, 
                    new EmployeeSkill { Skill = skills[1] }, 
                    new EmployeeSkill { Skill = skills[3] }, 
                    new EmployeeSkill { Skill = skills[7] }, 
                    new EmployeeSkill { Skill = skills[10] }, 
                    new EmployeeSkill { Skill = skills[11] }, 
                }
            },
            new Employee { FirstName = "Rita", LastName = "Tucker", DateOfBirth = new DateTime(1988, 1, 20), 
                JobTitle = "IT Support Manager", HiringDate = new DateTime(2015, 6, 2), EmployeeType = EmploymentType.FullTime, 
                Email = "bshamalt@dummy.com", Skills = new List<EmployeeSkill> {   
                    new EmployeeSkill { Skill = skills[1] }, 
                    new EmployeeSkill { Skill = skills[3] }, 
                    new EmployeeSkill { Skill = skills[6] }, 
                    new EmployeeSkill { Skill = skills[7] }, 
                    new EmployeeSkill { Skill = skills[10] }, 
                    new EmployeeSkill { Skill = skills[11] }, 
                    new EmployeeSkill { Skill = skills[14] },
                    new EmployeeSkill { Skill = skills[15] }, 
                    new EmployeeSkill { Skill = skills[16] }, 
                    new EmployeeSkill { Skill = skills[17] }, 
                    new EmployeeSkill { Skill = skills[18] }, 
                    new EmployeeSkill { Skill = skills[19] }, 
                    new EmployeeSkill { Skill = skills[20] }, 
                    new EmployeeSkill { Skill = skills[21] },
                }
            },
            new Employee { FirstName = "Ermina", LastName = "Steiger", DateOfBirth = new DateTime(1991, 1, 20), 
                JobTitle = "HR Consultant", HiringDate = new DateTime(2017, 6, 2), EmployeeType = EmploymentType.FullTime, 
                Email = "esteiger@dummy.com", Skills = new List<EmployeeSkill> {   
                    new EmployeeSkill { Skill = skills[1] }, 
                    new EmployeeSkill { Skill = skills[5] }, 
                    new EmployeeSkill { Skill = skills[7] }, 
                    new EmployeeSkill { Skill = skills[8] }, 
                    new EmployeeSkill { Skill = skills[9] }, 
                    new EmployeeSkill { Skill = skills[10] }, 
                    new EmployeeSkill { Skill = skills[11] }, 
                    new EmployeeSkill { Skill = skills[12] }, 
                    new EmployeeSkill { Skill = skills[13] }, 
                }
            },
            new Employee { FirstName = "Uri", LastName = "Chumpken", DateOfBirth = new DateTime(1989, 1, 20), 
                JobTitle = "HR Manager", HiringDate = new DateTime(2012, 6, 2), EmployeeType = EmploymentType.FullTime, 
                Email = "uchumpken@dummy.com", Skills = new List<EmployeeSkill> {   
                    new EmployeeSkill { Skill = skills[1] }, 
                    new EmployeeSkill { Skill = skills[5] }, 
                    new EmployeeSkill { Skill = skills[7] }, 
                    new EmployeeSkill { Skill = skills[8] }, 
                    new EmployeeSkill { Skill = skills[9] }, 
                    new EmployeeSkill { Skill = skills[10] }, 
                    new EmployeeSkill { Skill = skills[11] }, 
                    new EmployeeSkill { Skill = skills[12] }, 
                    new EmployeeSkill { Skill = skills[13] }, 
                    new EmployeeSkill { Skill = skills[14] },
                    new EmployeeSkill { Skill = skills[15] }, 
                    new EmployeeSkill { Skill = skills[16] }, 
                    new EmployeeSkill { Skill = skills[17] }, 
                    new EmployeeSkill { Skill = skills[18] }, 
                    new EmployeeSkill { Skill = skills[19] }, 
                    new EmployeeSkill { Skill = skills[20] },
                }
            },
            new Employee { FirstName = "Mohammed", LastName = "Ali", DateOfBirth = new DateTime(1994, 5, 21), 
                JobTitle = "Customer Success Consultant", HiringDate = new DateTime(2018, 9, 2), EmployeeType = EmploymentType.FullTime, 
                Email = "mali@dummy.com", Skills = new List<EmployeeSkill> {   
                    new EmployeeSkill { Skill = skills[7] }, 
                    new EmployeeSkill { Skill = skills[8] }, 
                    new EmployeeSkill { Skill = skills[9] }, 
                    new EmployeeSkill { Skill = skills[10] }, 
                    new EmployeeSkill { Skill = skills[11] }, 
                    new EmployeeSkill { Skill = skills[12] }, 
                    new EmployeeSkill { Skill = skills[13] }, 
                }
            },
            new Employee { FirstName = "Yussuf", LastName = "Sharawi", DateOfBirth = new DateTime(1994, 5, 21), 
                JobTitle = "Customer Success Manager", HiringDate = new DateTime(2018, 9, 2), EmployeeType = EmploymentType.FullTime, 
                Email = "mali@dummy.com", Skills = new List<EmployeeSkill> {   
                    new EmployeeSkill { Skill = skills[7] }, 
                    new EmployeeSkill { Skill = skills[8] }, 
                    new EmployeeSkill { Skill = skills[9] }, 
                    new EmployeeSkill { Skill = skills[10] }, 
                    new EmployeeSkill { Skill = skills[11] }, 
                    new EmployeeSkill { Skill = skills[12] }, 
                    new EmployeeSkill { Skill = skills[13] }, 
                    new EmployeeSkill { Skill = skills[14] },
                    new EmployeeSkill { Skill = skills[15] }, 
                    new EmployeeSkill { Skill = skills[16] }, 
                    new EmployeeSkill { Skill = skills[17] }, 
                    new EmployeeSkill { Skill = skills[18] }, 
                    new EmployeeSkill { Skill = skills[19] }, 
                    new EmployeeSkill { Skill = skills[20] },
                }
            },
        };

        await dataContext.Skills.AddRangeAsync(skills);
        await dataContext.Employees.AddRangeAsync(Employees);

        await dataContext.SaveChangesAsync();
    }
}
