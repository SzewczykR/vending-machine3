using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending_machine2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; } 
        public Cash Cash { get; set; }
        public List<Drink> Drinks { get; set; } = new List<Drink>();
    }
}
