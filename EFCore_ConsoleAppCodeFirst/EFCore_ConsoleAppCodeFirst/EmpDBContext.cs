using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EFCore_ConsoleAppCodeFirst
{
    public class EmpDBContext:DbContext
    {
        public DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=DAISH\MSSQLSERVER01;database=MyDemoDB;integrated security=true;trustservercertificate=true;");
        }
    }
}

//Add-Migration InitialCreate
//Update-database

//scaffold-dbcontext "data source=DAISH\MSSQLSERVER01;database=MyDemoDB;integrated security=true;trustservercertificate=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models