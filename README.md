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
    
    namespace EmployeeAPI.Data<br/>
    {<br/>
        public class AppDbContext : DbContext<br/>
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) <br/>{ <br/>}
    
            public DbSet<Employee> Employees { get; set; }<br/>
        }<br/>
    }<br/>
<b>5. Add Connection String</b><br/>
   appsettings.json<br/>
   "ConnectionStrings": {<br/>
  "DefaultConnection": "Server=YOUR_SQL_SERVER_NAME;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;"<br/>
  }<br/>
<b>6. Register DbContext in Program.cs</b><br/>
   using EmployeeAPI.Data;<br/>
    using Microsoft.EntityFrameworkCore;<br/>
    
    var builder = WebApplication.CreateBuilder(args);<br/>
    
    builder.Services.AddDbContext<AppDbContext>(options =><br/>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));<br/>
    
    // Add Controller + Swagger<br/>
    builder.Services.AddControllers();<br/>
    builder.Services.AddEndpointsApiExplorer();<br/>
    builder.Services.AddSwaggerGen();<br/>
    
    var app = builder.Build();<br/>
    
    if (app.Environment.IsDevelopment())<br/>
    {<br/>
        app.UseSwagger();<br/>
        app.UseSwaggerUI();<br/>
    }<br/>
    
    app.UseHttpsRedirection();<br/>
    app.UseAuthorization();<br/>
    
    app.MapControllers();<br/>
    
    app.Run();<br/>
<b>7. Create Controller</b><br/>
   Controllers/EmployeesController.cs<br/>
<b>8. Create DB using Migration</b><br/>
   dotnet ef migrations add InitialCreate<br/>
   dotnet ef database update<br/>
<b>9. Run & Test</b><br/>
   dotnet run<br/>
   dotnet watch<br/>



