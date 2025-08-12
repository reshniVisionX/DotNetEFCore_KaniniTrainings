using Microsoft.EntityFrameworkCore;

namespace EFCore_MVC_CodeFirst.Models
{
    public class StudentContext:DbContext
    {
        public DbSet<Students> students { get; set; }
        public DbSet<Items> items { get; set; }
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("data source=DAISH\\MSSQLSERVER01;database=MyDemoDB;integrated security=true;trustservercertificate=true;"); // ❌ Don't do this if using DI
        //}


    }
}
