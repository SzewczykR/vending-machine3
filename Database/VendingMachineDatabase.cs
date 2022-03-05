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
    }
}
