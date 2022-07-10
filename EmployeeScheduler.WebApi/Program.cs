using System.Reflection;
using System.Text.Json.Serialization;
using EmployeeScheduler.Data.Database;
using EmployeeScheduler.Data.Repositories;
using EmployeeScheduler.Models.Interfaces;
using EmployeeScheduler.WebApi.Data;
using EmployeeScheduler.WebApi.Interfaces.Employees;
using EmployeeScheduler.WebApi.Helpers;
using EmployeeScheduler.WebApi.Interfaces.Skills;
using EmployeeScheduler.WebApi.Services.Employees;
using EmployeeScheduler.WebApi.Services.Skills;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using EmployeeScheduler.WebApi.Interfaces.AuditTrails;
using EmployeeScheduler.WebApi.Services.AuditTrails;

var builder = WebApplication.CreateBuilder(args);
var mapper = AutoMapperProfile.RegisterAutoMapper().CreateMapper();

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IAuditTrailService, AuditTrailService>();

// builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),  b => b.MigrationsAssembly("EmployeeScheduler.WebApi")));

/*I am using in memory database for my testing purposes. */
builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(databaseName: "EmployeeScheduler"));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Employee Scheduler API project",
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();

var app = builder.Build();

/*For testing and viewing purposes I have seeded some data*/
try 
{
    using var scope = app.Services.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    
    // await dataContext.Database.MigrateAsync();
    await Seed.SeedData(dataContext);
}
catch(Exception ex)
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration.");
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeScheduler.WebApi v1");
    });
}

app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins("http://localhost:4200"));
    
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
