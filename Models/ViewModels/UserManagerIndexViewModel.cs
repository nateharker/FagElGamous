using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models.ViewModels
{
    public class UserManagerIndexViewModel
    {
        public List<UserRolesViewModel> Users { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string UserTypeSelected { get; set; }
    }
}
