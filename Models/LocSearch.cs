using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models
{
    public class LocSearch
    {
        [Required]
        public string NorthSouth { get; set; }
        [Required]
        public int NSLow { get; set; }
        public int NSHigh { get; set; }
        [Required]
        public string EastWest { get; set; }
        [Required]
        public int EWLow { get; set; }
        public int EWHigh { get; set; }
        public string Subplot { get; set; }
        public int BurialNumber { get; set; }
    }
}
