using MediatR;
using Microsoft.EntityFrameworkCore;
using RonwellHR.Application.HRReports.Queries;
using RonwellHR.Application.Mapping;
using RonwellHR.Data;
using RonwellHR.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext with SQL Server and specify the migrations assembly.
IServiceCollection serviceCollection = builder.Services.AddDbContext<HRDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("RonwellHR.Data")
    ));

// Register MediatR with multiple assemblies (Program's assembly and HRReports assembly)
builder.Services.AddMediatR(typeof(Program), typeof(GetHRReportQueryHandler));

// Register AutoMapper by scanning all profiles
builder.Services.AddAutoMapper(typeof(EmployeeProfile), typeof(ProjectProfile), typeof(TrainingProfile));

// Register repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();

// Add MVC controllers with views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Use static files middleware to serve CSS, JS, images, etc.
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Set up default routing; remove MapStaticAssets if not defined
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
