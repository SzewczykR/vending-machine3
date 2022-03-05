using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vending_machine2.Models;

namespace vending_machine2.Database
{
    public class VendingMachineDatabase : DbContext
    {
        public DbSet<VendingMachine> VendingMachines { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Cash> Cashes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=:..\\..\\Database\\VendingMachine.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VendingMachine>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasOne(e => e.Cash);
                e.HasMany(e => e.Drinks);
            });

            modelBuilder.Entity<Drink>().HasKey(d => d.Id);
            modelBuilder.Entity<Cash>().HasKey(c => c.Id);


            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasOne(e => e.Cash);
                e.HasMany(e => e.Drinks);
            });

        }


    }
}
