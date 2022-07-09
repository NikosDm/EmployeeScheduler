using EmployeeScheduler.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeScheduler.Data.Database;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions options): base(options) { }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<AuditTrail> AuditTrails { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) 
    {
        base.OnModelCreating(builder);

        builder.Entity<AuditTrail>()
            .Property(x => x.AudiTrailID)
            .HasDefaultValueSql("NEWID()");
        
        builder.Entity<Employee>()
            .Property(x => x.EmployeeID)
            .HasDefaultValueSql("NEWID()");

        builder.Entity<Skill>()
            .Property(x => x.SkillID)
            .HasDefaultValueSql("NEWID()");
        
        builder.Entity<EmployeeSkill>()
            .HasKey(es => new { es.EmployeeID, es.SkillID });

        builder.Entity<EmployeeSkill>()
            .HasOne(m => m.Employee)
            .WithMany(w => w.Skills)
            .HasForeignKey(k => k.EmployeeID)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.Entity<EmployeeSkill>()
            .HasOne(m => m.Skill)
            .WithMany(w => w.EmployeeSkills)
            .HasForeignKey(k => k.SkillID)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}
