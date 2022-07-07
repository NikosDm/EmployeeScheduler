using System.Reflection;
using EmployeeScheduler.Data.Database;
using EmployeeScheduler.Data.Repositories;
using EmployeeScheduler.Models.Interfaces;
using EmployeeScheduler.WebApi.Employees.Interfaces;
using EmployeeScheduler.WebApi.Helpers;
using EmployeeScheduler.WebApi.Interfaces.Skills;
using EmployeeScheduler.WebApi.Services.Employees;
using EmployeeScheduler.WebApi.Services.Skills;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var mapper = AutoMapperProfile.RegisterAutoMapper().CreateMapper();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ISkillService, SkillService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),  b => b.MigrationsAssembly("EmployeeScheduler.WebApi")));
// builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(databaseName: "EmployeeScheduler"));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Employee Scheduler API project",
    });
    
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
