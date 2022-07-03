using EmployeeScheduler.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeScheduler.Data.Database;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions options): base(options) { }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<SkillCategory> SkillCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) 
    {
        base.OnModelCreating(builder);

        builder.Entity<SkillCategory>()
            .HasKey(k => k.CategoryID);
        
        builder.Entity<Employee>()
            .HasKey(k => k.EmployeeID);

        builder.Entity<Skill>()
            .HasOne(ur => ur.Category)
            .WithOne(u => u.Skill)
            .HasForeignKey<SkillCategory>(f => f.SkillID)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<EmployeeSkill>()
            .HasKey(es => new { es.EmployeeID, es.SkillID });

        builder.Entity<EmployeeSkill>()
            .HasOne(m => m.Employee)
            .WithMany(w => w.Skills)
            .HasForeignKey(k => k.EmployeeID)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<EmployeeSkill>()
            .HasOne(m => m.Skill)
            .WithMany(w => w.EmployeeSkills)
            .HasForeignKey(k => k.SkillID)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
