Employee Management REST API using .NET 7 / .NET 8, EF Core, and SQL Server

Following are the steps

1. Create the Project
   dotnet new webapi -n EmployeeAPI
   cd EmployeeAPI
2. Install EF Core Packages
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
  dotnet add package Microsoft.EntityFrameworkCore.Tools
3. Create Model
   Models/Employee.cs
4. Configure DBContext
   Data/AppDbContext.cs
    using Microsoft.EntityFrameworkCore;
    using EmployeeAPI.Models;
    
    namespace EmployeeAPI.Data
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
            public DbSet<Employee> Employees { get; set; }
        }
    }
5. Add Connection String
   appsettings.json
   "ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SQL_SERVER_NAME;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
6. Register DbContext in Program.cs
   using EmployeeAPI.Data;
    using Microsoft.EntityFrameworkCore;
    
    var builder = WebApplication.CreateBuilder(args);
    
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    
    // Add Controller + Swagger
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    
    var app = builder.Build();
    
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    app.UseHttpsRedirection();
    app.UseAuthorization();
    
    app.MapControllers();
    
    app.Run();
7. Create Controller
   Controllers/EmployeesController.cs
8. Create DB using Migration
   dotnet ef migrations add InitialCreate
   dotnet ef database update
9. Run & Test
   dotnet run
   dotnet watch



