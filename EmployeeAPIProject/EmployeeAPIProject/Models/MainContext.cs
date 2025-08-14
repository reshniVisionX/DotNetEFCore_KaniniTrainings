using System.Collections.Generic;
using System.Reflection.Emit;
using EmployeeAPIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIProject.Models
{
    public class MainContext : DbContext 
    {
        public DbSet<Employee> employees { get; set; }
        public DbSet<Project> projects { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Projects)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.ProjectId);

            modelBuilder.Entity<Employee>()
               .Property(e => e.Salary)
               .HasPrecision(18, 2);

            modelBuilder.Entity<Project>()
                .Property(p => p.Budget)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Project>().HasData(
        
    new Project
    {
        ProjectId = 1,
        ProjectName = "A1 development",
        ProjectCode = "PA001",
        StartDate = new DateTime(2025, 8, 13),
        EndDate = new DateTime(2026, 2, 13),
        Budget = 100000
    },
    new Project
    {
        ProjectId = 2,
        ProjectName = "QA testing",
        ProjectCode = "PB002",
        StartDate = new DateTime(2025, 8, 13),
        EndDate = new DateTime(2026, 8, 13),
        Budget = 200000
    }
   );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, Name = "Alice", Email = "alice123@gmail.com", EmployeeCode = "E001", designation = "Developer", Salary = 60000, ProjectId = 1 },
                new Employee { EmployeeId = 2, Name = "Bob", Email = "bob123@gmail.com", EmployeeCode = "E002", designation = "Manager", Salary = 80000, ProjectId = 2 }
                );
        }
    }
}
