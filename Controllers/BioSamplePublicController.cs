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
