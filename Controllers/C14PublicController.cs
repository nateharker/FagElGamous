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
    public class C14PublicController : Controller
    {
        private readonly BYUExcavationDbContext _context;

        public C14PublicController(BYUExcavationDbContext context)
        {
            _context = context;
        }

        // GET: C14Public
        public async Task<IActionResult> Index()
        {
            var bYUExcavationDbContext = _context.C14data.Include(c => c.Burial);
            return View(await bYUExcavationDbContext.ToListAsync());
        }

        // GET: C14Public/Details/5
        public async Task<IActionResult> Details(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c14data = await _context.C14data
                .Include(c => c.Burial)
                .FirstOrDefaultAsync(m => m.C14Id == id);
            if (c14data == null)
            {
                return NotFound();
            }

            return View(c14data);
        }

         private bool C14dataExists(double id)
        {
            return _context.C14data.Any(e => e.C14Id == id);
        }
    }
}
