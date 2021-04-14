using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FagElGamous.Models;
using FagElGamous.Models.ViewModels;

namespace FagElGamous
{
    public class BioSamplePublicController : Controller
    {
        private readonly BYUExcavationDbContext _context;

        public BioSamplePublicController(BYUExcavationDbContext context)
        {
            _context = context;
        }

        // GET: BioSamplePublic
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

        [HttpPost]
        public async Task<IActionResult> BurialLocSearch(LocSearch search, int pageNum = 1)
        {
            if (ModelState.IsValid)
            {
                int pageSize = 5;
                int nsHigh = search.NSLow + 10;
                int ewHigh = search.EWLow + 10;
                string burialId = search.NorthSouth + search.NSLow.ToString() + nsHigh.ToString() + search.EastWest + search.EWLow.ToString() + ewHigh.ToString() + search.Subplot + search.BurialNumber.ToString();
                return View("Index", new BurialListViewModel
                {
                    BioSampleDatas = await _context.BioSampleData
                    .Where(x => x.BurialId.Contains(burialId))
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(),

                    PageNumberingInfo = new PageNumberingInfo
                    {
                        NumItemsPerPage = pageSize,
                        CurrentPage = pageNum,
                        TotalNumItems = (burialId == null ? _context.BioSampleData.Count() : _context.BioSampleData.Where(x => x.BurialId == burialId).Count())
                    }
                });
            }
            return RedirectToAction("Index");
        }

        // GET: BioSamplePublic/Details/5
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

        private bool BioSampleDataExists(double id)
        {
            return _context.BioSampleData.Any(e => e.BioSampleId == id);
        }
    }
}
