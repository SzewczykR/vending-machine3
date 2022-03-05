using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending_machine2.Models
{
    public abstract class VendingMachineItem
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public double Price { get; set; }   
    }
}
