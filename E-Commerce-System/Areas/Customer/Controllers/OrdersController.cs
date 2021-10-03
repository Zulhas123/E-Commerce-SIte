using E_Commerce_System.Data;
using E_Commerce_System.Models;
using E_Commerce_System.Session;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_System.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrdersController : Controller
    {
        private ApplicationDbContext _db;

        public OrdersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Get Check out method
        public IActionResult CheckOut()
        {
            return View();
        }

        //Post Check out Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOut(Order anorder)
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");//Get data from Session
            if (products != null)
            {
                foreach(var product in products)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.ProductId = product.Id;
            
                    anorder.OrderDetails.Add(orderDetails);
                }
            }
            anorder.OrderNo = GetOrderNo(); //Here Order No Bind
            _db.Order.Add(anorder);
            await _db.SaveChangesAsync();
            HttpContext.Session.Set("products",new List<Products>()); //Session Will be Null
            return View();
        }

        //Note:For Dynamically Order No Increment like(1,2,3,) Or AutoCode
        public string GetOrderNo()
        {
            int rowCount = _db.Order.ToList().Count()+1;
            return rowCount.ToString("000");

        }
        
    }
}
