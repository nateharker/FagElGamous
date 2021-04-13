using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FagElGamous.Models;

namespace FagElGamous
{
    public class PublicController : Controller
    {
        private readonly BYUExcavationDbContext _context;

        public PublicController(BYUExcavationDbContext context)
        {
            _context = context;
        }

        // GET: Public
        public async Task<IActionResult> Index()
        {
            return View(await _context.BurialData.ToListAsync());
        }

        // GET: Public/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burialData = await _context.BurialData
                .FirstOrDefaultAsync(m => m.BurialId == id);
            if (burialData == null)
            {
                return NotFound();
            }

            return View(burialData);
        }

        private bool BurialDataExists(string id)
        {
            return _context.BurialData.Any(e => e.BurialId == id);
        }
    }
}
