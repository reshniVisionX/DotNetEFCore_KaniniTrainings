using Microsoft.EntityFrameworkCore;

namespace MVC_CodeFirst.Models
{
    public class MainContext:DbContext
    {
        public DbSet<Products> Products { get; set; }
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }
        //called during migration (update execution)

    }
}
