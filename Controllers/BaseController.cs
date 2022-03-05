using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vending_machine2.Database;

namespace vending_machine2.Controllers
{


    public abstract class BaseController
    {
        protected VendingMachineDatabase _database;

        protected BaseController(VendingMachineDatabase database)
        {
            _database = database;
        }
     }
}
