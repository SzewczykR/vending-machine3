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
        public DbSet<VendingMachineVM> VendingMachines { get; set; }
        public DbSet<DrinkVM> Drinks { get; set; }
        public DbSet<CashVM> Cashes { get; set; }
        public DbSet<UserVM> Users { get; set; }

    public void Initialize()
        {
            ClearAll();

            VendingMachines.Add(new VendingMachineVM()
            {
                Drinks = new List<DrinkVM>()
                {
                    new DrinkVM() {Name = "Cola", Price = 3.49 , Capacity = 500},
                    new DrinkVM() { Name = "Fanta", Price = 3.89 , Capacity = 500},
                    new DrinkVM() { Name = "Sprite", Price = 3.29 , Capacity = 500},
                    new DrinkVM() { Name = "Monster", Price = 6.69, Capacity = 500 },
                    new DrinkVM() { Name = "Lipton", Price = 4.20, Capacity = 330 },
                    new DrinkVM() { Name = "Water", Price = 2.80, Capacity = 330 }
                },
                Cash = new CashVM() { Amount = 100 }
            });

            Users.Add(new UserVM()
            {
                Cash = new CashVM() { Amount = 100 }
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

            modelBuilder.Entity<VendingMachineVM>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasOne(e => e.Cash);
                e.HasMany(e => e.Drinks);
            });

            modelBuilder.Entity<DrinkVM>().HasKey(d => d.Id);
            modelBuilder.Entity<CashVM>().HasKey(c => c.Id);


            modelBuilder.Entity<UserVM>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasOne(e => e.Cash);
                e.HasMany(e => e.Drinks);
            });

        }


    }
}
