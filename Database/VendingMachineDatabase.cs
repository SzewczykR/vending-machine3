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

    public void Initialize()
        {
            ClearAll();

            VendingMachines.Add(new VendingMachine()
            {
                Drinks = new List<Drink>()
                {
                    new Drink() {Name = "Cola", Price = 3.49 , Capacity = 500},
                    new Drink() { Name = "Fanta", Price = 3.89 , Capacity = 500},
                    new Drink() { Name = "Sprite", Price = 3.29 , Capacity = 500},
                    new Drink() { Name = "Monster", Price = 6.69, Capacity = 500 },
                    new Drink() { Name = "Lipton", Price = 4.20, Capacity = 330 },
                    new Drink() { Name = "Water", Price = 2.80, Capacity = 330 }
                },
                Cash = new Cash() { Amount = 100 }
            });

            Users.Add(new User()
            {
                Cash = new Cash() { Amount = 100 }
            });

            SaveChanges();
        }

        private void ClearAll()
        {
            Drinks.RemoveRange(Drinks);
            Cashes.RemoveRange(Cashes);
            Users.RemoveRange(Users);
            VendingMachines.RemoveRange(VendingMachines);

            SaveChanges();
        }

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
