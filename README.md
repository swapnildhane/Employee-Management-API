# Employee Management REST API using .NET 7 / .NET 8, EF Core, and SQL Server

<b>Following are the steps</b><br/>

<b>1. Create the Project</b><br/>
   dotnet new webapi -n EmployeeAPI<br/>
   cd EmployeeAPI<br/>
<b>2. Install EF Core Packages</b><br/>
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer<br/>
  dotnet add package Microsoft.EntityFrameworkCore.Tools<br/>
<b>3. Create Model</b><br/>
   Models/Employee.cs<br/>
<b>4. Configure DBContext</b><br/>
   Data/AppDbContext.cs<br/>
    using Microsoft.EntityFrameworkCore;<br/>
    using EmployeeAPI.Models;<br/>
    
    namespace EmployeeAPI.Data
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
    
            public DbSet<Employee> Employees { get; set; }
        }
    }
<b>5. Add Connection String</b><br/>
   appsettings.json<br/>
   "ConnectionStrings": {<br/>
  "DefaultConnection": "Server=YOUR_SQL_SERVER_NAME;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;"<br/>
  }<br/>
<b>6. Register DbContext in Program.cs</b><br/>
   using EmployeeAPI.Data;<br/>
    using Microsoft.EntityFrameworkCore;<br/>
    
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
<b>7. Create Controller</b><br/>
   Controllers/EmployeesController.cs<br/>
<b>8. Create DB using Migration</b><br/>
   dotnet ef migrations add InitialCreate<br/>
   dotnet ef database update<br/>
<b>9. Run & Test</b><br/>
   dotnet run<br/>
   dotnet watch<br/>

# implement Repository + Service Layer
🎯 Why Repository Pattern?

When we use EF Core directly inside the Controller, like this:

_context.Employees.ToList();


→ Controller becomes heavy
→ Hard to modify database logic later
→ Hard to unit test
→ Violates Separation of Concerns
✅ Step-by-Step Implementation
1️⃣ Create Interface (Contract)

This defines what functions must exist (not how they work).

📌 Interfaces/IEmployeeRepository.cs
Why?

It guarantees consistent functionality.

Makes the code flexible → you can replace SQL with Oracle/Mongo later without changing controllers.

2️⃣ Repository Layer

This layer contains actual EF Core logic — how data is fetched.

📌 Repositories/EmployeeRepository.cs
Why?

Keeps EF Core code out of controller.

Easy to modify DB logic later.

3️⃣ Service Layer

This is business logic layer — rules, validations, calculations.

📌 Services/EmployeeService.cs
Why?

If tomorrow you need logic like:

Salary = Basic + Allowance - Tax
→ It will be written here, not in controller.

4️⃣ Register Dependencies in Program.cs

So .NET knows which implementation to use.
Why?

Enables Dependency Injection → Framework automatically provides objects.

5️⃣ Update Controller to use Service Layer

📌 Controllers/EmployeesController.cs
Why?

Easy to test.

Clean controller → Only handling API requests.

This is industry-level architecture.
You are now coding like a professional .NET developer 🚀🔥


   End of this code.

