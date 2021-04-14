using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FagElGamous.Models;
using Microsoft.AspNetCore.Authorization;

namespace FagElGamous
{
    [Authorize(Policy = "writepolicy")]
    public class C14ResearcherController : Controller
    {
        private readonly BYUExcavationDbContext _context;

        public C14ResearcherController(BYUExcavationDbContext context)
        {
            _context = context;
        }

        // GET: C14Researcher
        public async Task<IActionResult> Index()
        {
            var bYUExcavationDbContext = _context.C14data.Include(c => c.Burial);
            return View(await bYUExcavationDbContext.ToListAsync());
        }

        // GET: C14Researcher/Details/5
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

        // GET: C14Researcher/Create
        public IActionResult Create()
        {
            ViewData["BurialId"] = new SelectList(_context.BurialData, "BurialId", "BurialId");
            return View();
        }

        // POST: C14Researcher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("C14Id,BurialLocNs,NsLow,NsHigh,BurialLocEw,EwLow,EwHigh,Subplot,BurialNum,BurialArea,Rack,TubeNum,BurialDescription,SizeMl,Foci,C14Sample2017,LocationDetails,Questions,UnknownNumbers,Conventional14cAgeBp,_14cCalendarDate,Calibrated95CalendarDateMax,Calibrated95CalendarDateMin,Calibrated95CalendarDateSpan,Calibrated95CalendarDateAvg,Category,Notes,HeadDirection,BurialId")] C14data c14data)
        {
            if (ModelState.IsValid)
            {
                _context.Add(c14data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurialId"] = new SelectList(_context.BurialData, "BurialId", "BurialId", c14data.BurialId);
            return View(c14data);
        }

        // GET: C14Researcher/Edit/5
        public async Task<IActionResult> Edit(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c14data = await _context.C14data.FindAsync(id);
            if (c14data == null)
            {
                return NotFound();
            }
            ViewData["BurialId"] = new SelectList(_context.BurialData, "BurialId", "BurialId", c14data.BurialId);
            return View(c14data);
        }

        // POST: C14Researcher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(double id, [Bind("C14Id,BurialLocNs,NsLow,NsHigh,BurialLocEw,EwLow,EwHigh,Subplot,BurialNum,BurialArea,Rack,TubeNum,BurialDescription,SizeMl,Foci,C14Sample2017,LocationDetails,Questions,UnknownNumbers,Conventional14cAgeBp,_14cCalendarDate,Calibrated95CalendarDateMax,Calibrated95CalendarDateMin,Calibrated95CalendarDateSpan,Calibrated95CalendarDateAvg,Category,Notes,HeadDirection,BurialId")] C14data c14data)
        {
            if (id != c14data.C14Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(c14data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!C14dataExists(c14data.C14Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurialId"] = new SelectList(_context.BurialData, "BurialId", "BurialId", c14data.BurialId);
            return View(c14data);
        }

        private bool C14dataExists(double id)
        {
            return _context.C14data.Any(e => e.C14Id == id);
        }
    }
}
