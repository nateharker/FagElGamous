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
    public class BioSampleAdminController : Controller
    {
        private readonly BYUExcavationDbContext _context;

        public BioSampleAdminController(BYUExcavationDbContext context)
        {
            _context = context;
        }

        // GET: BioSampleAdmin
        public async Task<IActionResult> Index(int pageNum = 1)
        {
            int pageSize = 100;
            var bYUExcavationDbContext = _context.BioSampleData.Include(b => b.Burial);
            return View(new BioSampleListViewModel
            {
                BioSampleDatas = await bYUExcavationDbContext
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    TotalNumItems = _context.BioSampleData.Count()
                }
            });
        }
                

        // GET: BioSampleAdmin/Details/5
        public async Task<IActionResult> Details(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioSampleData = await _context.BioSampleData
                .Include(b => b.Burial)
                .FirstOrDefaultAsync(m => m.BioSampleId == id);
            if (bioSampleData == null)
            {
                return NotFound();
            }

            return View(bioSampleData);
        }

        // GET: BioSampleAdmin/Create
        public IActionResult Create()
        {
            ViewData["BurialId"] = new SelectList(_context.BurialData, "BurialId", "BurialId");
            return View();
        }

        // POST: BioSampleAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BioSampleId,RackNum,BagNum,BurialLocNs,NsLow,NsHigh,BurialLocEw,EwLow,EwHigh,Subplot,BurialNum,BurialItemId,BioSampleDate,PrevSampled,ClusterNum,Notes,Initials,BurialId")] BioSampleData bioSampleData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bioSampleData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurialId"] = new SelectList(_context.BurialData, "BurialId", "BurialId", bioSampleData.BurialId);
            return View(bioSampleData);
        }

        // GET: BioSampleAdmin/Edit/5
        public async Task<IActionResult> Edit(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioSampleData = await _context.BioSampleData.FindAsync(id);
            if (bioSampleData == null)
            {
                return NotFound();
            }
            ViewData["BurialId"] = new SelectList(_context.BurialData, "BurialId", "BurialId", bioSampleData.BurialId);
            return View(bioSampleData);
        }

        // POST: BioSampleAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(double id, [Bind("BioSampleId,RackNum,BagNum,BurialLocNs,NsLow,NsHigh,BurialLocEw,EwLow,EwHigh,Subplot,BurialNum,BurialItemId,BioSampleDate,PrevSampled,ClusterNum,Notes,Initials,BurialId")] BioSampleData bioSampleData)
        {
            if (id != bioSampleData.BioSampleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bioSampleData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BioSampleDataExists(bioSampleData.BioSampleId))
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
            ViewData["BurialId"] = new SelectList(_context.BurialData, "BurialId", "BurialId", bioSampleData.BurialId);
            return View(bioSampleData);
        }

        // GET: BioSampleAdmin/Delete/5
        public async Task<IActionResult> Delete(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioSampleData = await _context.BioSampleData
                .Include(b => b.Burial)
                .FirstOrDefaultAsync(m => m.BioSampleId == id);
            if (bioSampleData == null)
            {
                return NotFound();
            }

            return View(bioSampleData);
        }

        // POST: BioSampleAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(double id)
        {
            var bioSampleData = await _context.BioSampleData.FindAsync(id);
            _context.BioSampleData.Remove(bioSampleData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BioSampleDataExists(double id)
        {
            return _context.BioSampleData.Any(e => e.BioSampleId == id);
        }
    }
}
