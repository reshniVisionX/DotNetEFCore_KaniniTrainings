using Microsoft.EntityFrameworkCore;
using DemoAPI_JWTConnection.Model;

namespace DemoAPI_JWTConnection.Model
{
   public class MainContext:DbContext
    {
     
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {

        }
       public DbSet<DemoAPI_JWTConnection.Model.Clients> Clients { get; set; } = default!;
       public DbSet<DemoAPI_JWTConnection.Model.Categories> Categories { get; set; } = default!;
     
    }
}
