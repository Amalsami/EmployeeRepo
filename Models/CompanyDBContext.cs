using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EmployeeRep.Models
{
    public class CompanyDBContext :IdentityDbContext

    {
        
        public CompanyDBContext()
        {

        }
        public CompanyDBContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= DESKTOP-R3M46C9\\AA17;Initial Catalog= LayearDB;Integrated Security=True;TrustServerCertificate = True;");
          //  base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentLocation>().HasKey("DeptNumber", "Location");
            modelBuilder.Entity<WorksOnProject>().HasKey("EmpSSN", "projNum");
            modelBuilder.Entity<Dependent>().HasKey("EmpSSN", "Name");

            modelBuilder.Entity<Employee>().HasOne(s => s.Supervisor).WithMany(e => e.Employees);

            modelBuilder.Entity<Employee>().HasOne(e => e.DepartmentManege).WithOne(d => d.employeeManege);
            modelBuilder.Entity<Employee>().HasOne(e => e.DepartmentWork).WithMany(e => e.EmployeesWork);
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<DepartmentLocation> DepartmentLocation { get; set; }
        public DbSet<WorksOnProject> WorksOnProjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Dependent> Dependents { get; set; }


    }
}
