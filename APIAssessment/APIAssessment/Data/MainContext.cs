using APIAssessment.Model;
using Microsoft.EntityFrameworkCore;

namespace APIAssessment.Data
{
    public class MainContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
                 .HasMany(p => p.projects)
                 .WithMany(d => d.employees)
                 .UsingEntity(j => j.ToTable("EmployeeProject"));

          
        }
    }
}
