using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FagElGamous.Models;
using Microsoft.AspNetCore.Authorization;
using FagElGamous.Models.ViewModels;

namespace FagElGamous
{
    [Authorize(Policy = "deletepolicy")]
    public class C14AdminController : Controller
    {
        private readonly BYUExcavationDbContext _context;

        public C14AdminController(BYUExcavationDbContext context)
        {
            _context = context;
        }

        // GET: C14Admin
        public async Task<IActionResult> Index(int pageNum = 1)
        {
            int pageSize = 10;
            var bYUExcavationDbContext = _context.C14data.Include(c => c.Burial);
            return View(new BurialListViewModel
            {
                C14Datas = await bYUExcavationDbContext
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(),
                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    TotalNumItems = _context.C14data.Count()
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> BurialLocSearch(LocSearch search, int pageNum = 1)
        {
            if (ModelState.IsValid)
            {
                int pageSize = 5;
                int nsHigh = search.NSLow + 10;
                int ewHigh = search.EWLow + 10;
                string burialId = search.NorthSouth + search.NSLow.ToString() + nsHigh.ToString() + search.EastWest + search.EWLow.ToString() + ewHigh.ToString() + search.Subplot + search.BurialNumber.ToString();
                return View(new BurialListViewModel
                {
                    C14Datas = await _context.C14data
                    .Where(x => x.BurialId.Contains(burialId))
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(),

                    PageNumberingInfo = new PageNumberingInfo
                    {
                        NumItemsPerPage = pageSize,
                        CurrentPage = pageNum,
                        TotalNumItems = (burialId == null ? _context.C14data.Count() : _context.C14data.Where(x => x.BurialId == burialId).Count())
                    }
                });
            }
            return RedirectToAction("Index");
        }

        // GET: C14Admin/Details/5
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

        // GET: C14Admin/Create
        public IActionResult Create()
        {
            ViewData["BurialId"] = new SelectList(_context.BurialData, "BurialId", "BurialId");
            return View();
        }

        // POST: C14Admin/Create
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

        // GET: C14Admin/Edit/5
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

        // POST: C14Admin/Edit/5
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

        // GET: C14Admin/Delete/5
        public async Task<IActionResult> Delete(double? id)
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

        // POST: C14Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(double id)
        {
            var c14data = await _context.C14data.FindAsync(id);
            _context.C14data.Remove(c14data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool C14dataExists(double id)
        {
            return _context.C14data.Any(e => e.C14Id == id);
        }
    }
}
