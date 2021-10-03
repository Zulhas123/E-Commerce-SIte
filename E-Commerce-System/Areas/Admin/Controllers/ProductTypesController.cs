using E_Commerce_System.Data;
using E_Commerce_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]                  // To Create Edit Remove  ProductType first  log in then ...... .
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

       // [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_db.productTypes.ToList());
        }


        //Create Get Action Method

      
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.productTypes.Add(productTypes);
                await _db.SaveChangesAsync();
                TempData["Save"] = "Save Product Type Successfully";
                return RedirectToAction(nameof(Index));

            }

            return View(productTypes);
        }


        //Edit Get Action Method
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ProductType = _db.productTypes.Find(id);

            if (ProductType == null)
            {
                return NotFound();
            }
            return View(ProductType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Update(productTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(productTypes);
        }

        //Details Get Action Method
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ProductType = _db.productTypes.Find(id);

            if (ProductType == null)
            {
                return NotFound();
            }
            return View(ProductType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(ProductTypes productTypes)
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

            var ProductType = _db.productTypes.Find(id);

            if (ProductType == null)
            {
                return NotFound();
            }
            return View(ProductType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, ProductTypes productTypes)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != productTypes.Id)
            {
                return NotFound();
            }

            var productType = _db.productTypes.Find(id);

            if (productType == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Remove(productType);
                await _db.SaveChangesAsync();
                TempData["Delete"] = "Delete Product Type Successfully";
                return RedirectToAction(nameof(Index));

            }

            return View(productTypes);
        }


    }
}
