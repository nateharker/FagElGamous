using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FagElGamous.Models;

namespace FagElGamous.Components
{
    public class SexPublicViewComponent : ViewComponent
    {
        private BYUExcavationDbContext _context;
        public SexPublicViewComponent(BYUExcavationDbContext context)
        {
            context = _context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.BurialData
                .Select(x => x.Sex)
                .Distinct());
        }
    }
}
