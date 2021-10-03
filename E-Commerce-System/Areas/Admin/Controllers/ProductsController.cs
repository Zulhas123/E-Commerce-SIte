using E_Commerce_System.Data;
using E_Commerce_System.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private ApplicationDbContext _db;
        private IHostingEnvironment _he;
        public ProductsController(ApplicationDbContext db,IHostingEnvironment he )
        {
            _db = db;
            _he = he;
        }
        public IActionResult Index()
        {
            return View(_db.Products.Include(c => c.productType).Include(p => p.SpacialTag).ToList());//For Get Relation table data using Include Method
        }
        [HttpPost]
        public IActionResult Index(Decimal? lowamount,Decimal? largeamount)//Condition Range wise data Show 
        {
            var products = _db.Products.Include(c => c.productType).Include(p => p.SpacialTag).Where(c => c.Price >= lowamount && c.Price <= largeamount).ToList();
            if(lowamount == null || largeamount == null)
            {
                products = _db.Products.Include(c => c.productType).Include(p => p.SpacialTag).ToList();
            }
            return View(products);
        }

        //Create Get Action Method
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ProductTypeId"] = new SelectList(_db.productTypes.ToList(),"Id", "ProductType");
            ViewData["TagId"] = new SelectList(_db.spacialTags.ToList(), "Id", "spacialTag");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Products products,IFormFile image)
        {

            var productSerch = _db.Products.FirstOrDefault(c => c.Name == products.Name); //For Existing Value does'not Save.
            if(productSerch != null)
            {
                ViewBag.message = "This Product is already Exist!";
                ViewData["ProductTypeId"] = new SelectList(_db.productTypes.ToList(), "Id", "ProductType");
                ViewData["TagId"] = new SelectList(_db.spacialTags.ToList(), "Id", "spacialTag");
                return View(products);
            }

            if (ModelState.IsValid)
            {
                if(image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    products.Image = "Images/" + image.FileName;
                }
                if(image == null)
                {
                    products.Image = "Images/no-image.jpg";
                }

                _db.Products.Add(products);
                await _db.SaveChangesAsync();
                TempData["Save"] = "Save Product  Successfully";
                return RedirectToAction(nameof(Index));

            }

            return View(products);
        }

        public IActionResult Edit(int? id )
        {
            ViewData["ProductTypeId"] = new SelectList(_db.productTypes.ToList(), "Id", "ProductType");
            ViewData["TagId"] = new SelectList(_db.spacialTags.ToList(), "Id", "spacialTag");

            if (id == null)
            {
                return NotFound();
            }
            var product = _db.Products.Include(c => c.productType).Include(p => p.SpacialTag).FirstOrDefault(f=>f.Id==id);
            if(product== null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Products products, IFormFile image)
        {
            var productSerch = _db.Products.FirstOrDefault(c => c.Name == products.Name); //For Existing Value does'not Save.
            if (productSerch != null)
            {
                ViewBag.message = "This Product is already Exist!";
                ViewData["ProductTypeId"] = new SelectList(_db.productTypes.ToList(), "Id", "ProductType");
                ViewData["TagId"] = new SelectList(_db.spacialTags.ToList(), "Id", "spacialTag");
                return View(products);
            }

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    products.Image = "Images/" + image.FileName;
                }
                if (image == null)
                {
                    products.Image = "Images/no-image.jpg";
                }



                _db.Update(products);
                await _db.SaveChangesAsync();
                TempData["Save"] = "Save Product  Successfully";
                return RedirectToAction(nameof(Index));

            }

            return View(products);

        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Product = _db.Products.Include(c => c.productType).Include(p => p.SpacialTag).FirstOrDefault(f => f.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }


        public ActionResult Delete(int? id)
        {
            if(id== null)
            {
                return NotFound();
            }

            var Product = _db.Products.Include(c=>c.productType).Include(t=>t.SpacialTag).Where(p => p.Id == id).FirstOrDefault();
            if(Product== null)
            {
                return NotFound();
            }
            return View(Product);

        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {

            if(id == null)
            {
                return NotFound();
            }
            var product = _db.Products.FirstOrDefault(c => c.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
