using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models.ViewModels
{
    public class PolicyRolesViewModel
    {
        public List<Microsoft.AspNetCore.Identity.IdentityRole> Roles { get; set; }
        public List<WriteRole> WriteRoles { get; set; }
        public List<DeleteRole> DeleteRoles { get; set; }
    }
}
