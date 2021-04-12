using FagElGamous.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Components
{
    public class UserTypeViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        public UserTypeViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {
            var users = _userManager.Users;
            return View(users
                .Select(x => x.UserType)
                .Distinct()
                .OrderBy(x => x)
                .ToList());
        }
    }
}
