using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models
{
    public class WriteRole
    {
        [Key]
        public int WriteRoleId { get; set; }
        [Required]
        public string Role { get; set; }

    }
}
