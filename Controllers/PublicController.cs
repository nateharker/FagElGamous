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
    public class PublicController : Controller
    {
        private readonly BYUExcavationDbContext _context;

        public PublicController(BYUExcavationDbContext context)
        {
            _context = context;
        }

        // GET: Public
        public async Task<IActionResult> Index(string? sex, int pageNum = 1)
        {
            int pageSize = 100;
            ViewBag.Sex = sex;
            return View(new BurialListViewModel
            {
                BurialDatas = await _context.BurialData
                .Where(x => x.Sex == sex || sex == null)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    TotalNumItems = (sex == null ? _context.BurialData.Count() : _context.BurialData.Where(x => x.Sex == sex).Count())
                },

                FilterString = sex
            }); 
        }

        public async Task<IActionResult> BurialDirection(string? direction, int pageNum)
        {
            int pageSize = 50;
            ViewBag.BurialDirection = direction;
            return View("Index", new BurialListViewModel
            {
                BurialDatas = await _context.BurialData
                .Where(x => x.BurialDirection == direction || direction == null)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    TotalNumItems = (direction == null ? _context.BurialData.Count() : _context.BurialData.Where(x => x.BurialDirection == direction).Count())
                },

                FilterString = direction
            });
        }

        public async Task<IActionResult> AgeFilter(string? age, int pageNum)
        {
            int pageSize = 50;
            ViewBag.Age = age;
            return View("Index", new BurialListViewModel
            {
                BurialDatas = await _context.BurialData
                .Where(x => x.AgeCode == age || age == null)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    TotalNumItems = (age == null ? _context.BurialData.Count() : _context.BurialData.Where(x => x.AgeCode == age).Count())
                },

                FilterString = age
            });
        }

        public async Task<IActionResult> HairFilter(string? hair, int pageNum)
        {
            int pageSize = 50;
            ViewBag.Hair = hair;
            return View("Index", new BurialListViewModel
            {
                BurialDatas = await _context.BurialData
                .Where(x => x.HairColorCode == hair || hair == null)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    TotalNumItems = (hair == null ? _context.BurialData.Count() : _context.BurialData.Where(x => x.HairColorCode == hair).Count())
                },

                FilterString = hair
            });
        }

        public async Task<IActionResult> WrappingFilter(string? wrapping, int pageNum)
        {
            int pageSize = 50;
            ViewBag.Wrapping = wrapping;
            return View("Index", new BurialListViewModel
            {
                BurialDatas = await _context.BurialData
                .Where(x => x.BurialWrapping == wrapping || wrapping == null)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    TotalNumItems = (wrapping == null ? _context.BurialData.Count() : _context.BurialData.Where(x => x.BurialWrapping == wrapping).Count())
                },

                FilterString = wrapping
            });
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
