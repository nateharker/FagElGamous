using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FagElGamous.Models;
using FagElGamous.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace FagElGamous
{
    [Authorize(Policy = "deletepolicy")]
    public class AdminController : Controller
    {
        private readonly BYUExcavationDbContext _context;

        public AdminController(BYUExcavationDbContext context)
        {
            _context = context;
        }

        // GET: Admin
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
            }); ;
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
                    BurialDatas = await _context.BurialData
                    .Where(x => x.BurialId.Contains(burialId))
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(),

                    PageNumberingInfo = new PageNumberingInfo
                    {
                        NumItemsPerPage = pageSize,
                        CurrentPage = pageNum,
                        TotalNumItems = (burialId == null ? _context.BurialData.Count() : _context.BurialData.Where(x => x.BurialId == burialId).Count())
                    }
                });
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Details/5
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

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BurialId,BurialLocNs,NsLow,NsHigh,BurialLocEw,EwLow,EwHigh,Subplot,BurialNum,AreaHillBurials,Tomb,YearExcav,MonthExcav,DateExcav,TimeExcav,ExcavRecorder,FieldBook,FieldBookPg,Goods,ArtifactFound,ArtifactDescription,HairPresent,HairColorCode,BurialHairColor,FaceBundle,BurialSampleTaken,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,DescriptionOfTaken,EstimateLivingStature,LengthOfRemains,BurialLength,BurialDepth,BurialSituationNotes,WestToHead,WestToFeet,SouthToHead,SouthToFeet,SampleNumber,PreservationIndex,BurialPreservation,BurialMaterials,BurialWrapping,BurialDirection,HeadDirection,ClusterYn,ClusterNum,Sex,SexMethod,GenderGe,GeFunctionTotal,AgeAtDeath,AgeCode,AgeMethod,BurialAdultChild,ToBeCo0firmed,B1uSample,BodyAnalysis,YearOnSkull,MonthOnSkull,DateOnSkull,SkullAtMagazi0e,Postcra0iaAtMagazi0e,SexSkull2018,AgeSkull2018,ArcGisRefNum,BasilarSuture,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpRamus,DorsalPitting,ForemanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,SkullTrauma,Postcra0iaTrauma,CribraOrbitala,PoroticHyperostosis,PoroticHyperostosisLocations,MetopicSuture,ButtonOsteoma,OsteologyUnknownComment,TmjOa,LinearHypolasiaEnamel,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion,OsteologyNotes")] BurialData burialData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(burialData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(burialData);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burialData = await _context.BurialData.FindAsync(id);
            if (burialData == null)
            {
                return NotFound();
            }
            return View(burialData);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BurialId,BurialLocNs,NsLow,NsHigh,BurialLocEw,EwLow,EwHigh,Subplot,BurialNum,AreaHillBurials,Tomb,YearExcav,MonthExcav,DateExcav,TimeExcav,ExcavRecorder,FieldBook,FieldBookPg,Goods,ArtifactFound,ArtifactDescription,HairPresent,HairColorCode,BurialHairColor,FaceBundle,BurialSampleTaken,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,DescriptionOfTaken,EstimateLivingStature,LengthOfRemains,BurialLength,BurialDepth,BurialSituationNotes,WestToHead,WestToFeet,SouthToHead,SouthToFeet,SampleNumber,PreservationIndex,BurialPreservation,BurialMaterials,BurialWrapping,BurialDirection,HeadDirection,ClusterYn,ClusterNum,Sex,SexMethod,GenderGe,GeFunctionTotal,AgeAtDeath,AgeCode,AgeMethod,BurialAdultChild,ToBeCo0firmed,B1uSample,BodyAnalysis,YearOnSkull,MonthOnSkull,DateOnSkull,SkullAtMagazi0e,Postcra0iaAtMagazi0e,SexSkull2018,AgeSkull2018,ArcGisRefNum,BasilarSuture,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpRamus,DorsalPitting,ForemanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,SkullTrauma,Postcra0iaTrauma,CribraOrbitala,PoroticHyperostosis,PoroticHyperostosisLocations,MetopicSuture,ButtonOsteoma,OsteologyUnknownComment,TmjOa,LinearHypolasiaEnamel,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion,OsteologyNotes")] BurialData burialData)
        {
            if (id != burialData.BurialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(burialData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BurialDataExists(burialData.BurialId))
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
            return View(burialData);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(string id)
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

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var burialData = await _context.BurialData.FindAsync(id);
            _context.BurialData.Remove(burialData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BurialDataExists(string id)
        {
            return _context.BurialData.Any(e => e.BurialId == id);
        }
    }
}
