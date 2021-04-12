using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models
{
    public class DeleteRole
    {
        [Key]
        public int DeleteRoleId { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
