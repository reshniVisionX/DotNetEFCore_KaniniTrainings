using Microsoft.EntityFrameworkCore;

namespace MVC_CodeFirst.Models
{
    public class MainContext:DbContext
    {
        //plays a major role in Entity Framework Core, it is the bridge between your domain or entity classes and the database.
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        //constructor called during execution
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }
        //called during migration (update execution)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=DAISH\\MSSQLSERVER01;database=MyDotnet;integrated security=true;trustservercertificate=true;"); // ❌ Don't do this if using DI
        }
    }
}
