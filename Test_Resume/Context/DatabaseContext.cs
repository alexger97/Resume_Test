
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Resume.Model;

namespace Test_Resume.Context
{
   
        public class DatabaseContext : DbContext
        {
        public DatabaseContext()
        {  
             Database.Migrate();
        }
         public DbSet<ElementGraph>  ElementGraphs{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=..\\..\\database.db");
        }
    }
}

