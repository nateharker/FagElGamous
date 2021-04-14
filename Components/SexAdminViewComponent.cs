using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FagElGamous.Models;

namespace FagElGamous.Components
{
    public class SexAdminViewComponent : ViewComponent
    {
        private BYUExcavationDbContext _context;
        public SexAdminViewComponent(BYUExcavationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.BurialData
                .Select(x => x.Sex)
                .Distinct());
        }
    }
}
