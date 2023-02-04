using EmployeeRep.Models;
using EmployeeRep.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CompanyDBContext>(options => options.UseSqlServer("Data Source= DESKTOP-R3M46C9\\AA17;Initial Catalog= LayearDB;Integrated Security=True;TrustServerCertificate = True;"));//scoped

//builder.Services.AddSingleton<IEmployeeRepo , EmployeeRepo>();
//builder.Services.AddTransient<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped<IEmployeeRepo,EmployeeRepo>();
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<CompanyDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
