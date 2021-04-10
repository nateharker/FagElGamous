using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models
{
    public class AppUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        public string UserType { get; set; }
        [PersonalData]
        public string OrganizationName { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;
        [PersonalData]
        public byte[] ProfilePicture { get; set; }
  
    }
}
