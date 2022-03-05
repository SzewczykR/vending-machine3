using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending_machine2.ModelsVM
{
    public class UserVM
    {
        [Key]
        public int Id { get; set; } 
        public CashVM Cash { get; set; }
        public List<DrinkVM> Drinks { get; set; } = new List<DrinkVM>();
    }
}
