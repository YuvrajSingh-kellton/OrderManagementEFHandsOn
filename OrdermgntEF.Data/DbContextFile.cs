using Microsoft.EntityFrameworkCore;
using OrdermgntEF.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdermgntEF.Data
{
    public class DbContextFile : DbContext
    {
        public DbSet<Customer> Customors { get; set; }
        public DbSet<ItemMaster> ItemMasters { get; set; }

        public DbContextFile()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-0P56O06;Database=EFDatabase;Trusted_Connection=True;");

        }
    }
}
