using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending_machine2.Models
{
    public class Cash
    {
        [Key]
        public int Id { get; set; }

        public double Amount { get; set; }  
    }
}
