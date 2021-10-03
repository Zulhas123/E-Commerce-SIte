using E_Commerce_System.Data;
using E_Commerce_System.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpacialTagController : Controller
    {
        private ApplicationDbContext _db;

        public SpacialTagController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.spacialTags.ToList());
        }



        //Create Get Action Method
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpacialTag spTag)
        {
            if (ModelState.IsValid)
            {
                _db.spacialTags.Add(spTag);
                await _db.SaveChangesAsync();
                TempData["Save"] = "Save SpecialTag  Successfully";
                return RedirectToAction(nameof(Index));

            }

            return View(spTag);
        }



        //Edit Get Action Method
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ProductType = _db.spacialTags.Find(id);

            if (ProductType == null)
            {
                return NotFound();
            }
            return View(ProductType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpacialTag spTag)
        {
            if (ModelState.IsValid)
            {
                _db.Update(spTag);
                await _db.SaveChangesAsync();
                TempData["Edit"] = "Edit SpecialTag  Successfully";
                return RedirectToAction(nameof(Index));

            }

            return View(spTag);
        }



        //Details Get Action Method
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spcaltag = _db.spacialTags.Find(id);

            if (spcaltag == null)
            {
                return NotFound();
            }
            return View(spcaltag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(SpacialTag spTag)
        {

            return RedirectToAction(nameof(Index));


        }


        //Delete Get Action Method
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specailTag = _db.spacialTags.Find(id);

            if (specailTag == null)
            {
                return NotFound();
            }
            return View(specailTag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, SpacialTag spTag)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != spTag.Id)
            {
                return NotFound();
            }

            var SpTag = _db.spacialTags.Find(id);

            if (SpTag == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Remove(SpTag);
                await _db.SaveChangesAsync();
                TempData["Delete"] = "Delete SpecialTag  Successfully";
                return RedirectToAction(nameof(Index));

            }

            return View(SpTag);
        }



    }
}
