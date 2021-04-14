﻿using System;
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
    public class C14PublicController : Controller
    {
        private readonly BYUExcavationDbContext _context;

        public C14PublicController(BYUExcavationDbContext context)
        {
            _context = context;
        }

        // GET: C14Public
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
                return View("Index", new BurialListViewModel
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
