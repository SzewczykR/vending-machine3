using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vending_machine2.Database;
using vending_machine2.Models;

namespace vending_machine2.Controllers
{
    public class DrinkController : BaseController
    {
        DrinkController(VendingMachineDatabase database) : base(database) { }

        public DrinkVM Create(DrinkVM drink)
        {
            _database.Drinks.Add(drink);
            _database.SaveChanges();
            return drink;
        }
        public DrinkVM Read(int id)
        {
            DrinkVM drink = _database.Drinks.FirstOrDefault(e => e.Id == id);
            return drink;
        }
        public DrinkVM Edit(int id, DrinkVM drink)
        {
            DrinkVM editDrink = _database.Drinks.FirstOrDefault(e => e.Id == id);
            if (editDrink != null)
            {
                editDrink.Name = drink.Name;
                editDrink.Price = drink.Price;
                editDrink.Capacity = drink.Capacity;
            }
            _database.Drinks.Update(editDrink);
            _database.SaveChanges();
            return editDrink;
        }
        public bool Remove(int id)
        {
            DrinkVM drink = _database.Drinks.FirstOrDefault(e => e.Id == id);
            if (drink != null)
            {
                _database.Remove(drink);
                _database.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
