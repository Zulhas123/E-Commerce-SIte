using E_Commerce_System.Data;
using E_Commerce_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_System.Areas.Customer
{
    [Area("Customer")]
    public class UserController : Controller
    {
        UserManager<IdentityUser> _userManager; // for Identity
        ApplicationDbContext _db;
        public UserController(UserManager<IdentityUser> userManager , ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.ApplicationUser.ToList());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUser User)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(User, User.PasswordHash);
                if (result.Succeeded)
                {
                    var IsSaveRole = await _userManager.AddToRoleAsync(User,"User");
                    TempData["Save"] = "User Create Successfully";
                    return RedirectToAction(nameof(Index));
                }


                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
               
            }
            return View();
        }

        public async Task<IActionResult> Edit( string id)
        {
            var user = _db.ApplicationUser.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser User)
        {
            var userInfo = _db.ApplicationUser.FirstOrDefault(c => c.Id == User.Id);
            if (userInfo == null)
            {
                return NotFound();
            }
            userInfo.FirstName = User.FirstName;
            userInfo.LastName = User.LastName;
            var result = await _userManager.UpdateAsync(userInfo);
            if (result.Succeeded)
            {
                TempData["Save"] = "User Update Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(userInfo);
        }

        public async Task<IActionResult> Details(string id)
        {
            var user = _db.ApplicationUser.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public async Task<IActionResult> LockOut( string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = _db.ApplicationUser.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> LockOut(ApplicationUser user)
        {
           
            var userinfo = _db.ApplicationUser.FirstOrDefault(c => c.Id == user.Id);
            if (userinfo == null)
            {
                return NotFound();
            }
            userinfo.LockoutEnd = DateTime.Now.AddYears(100);
            int rowAffected = _db.SaveChanges();
            if(rowAffected > 0)
            {
                TempData["Save"] = "User have been LockOut Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(userinfo);
        }

        public async Task<IActionResult> Active(string id)
        {
            var user = _db.ApplicationUser.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }



        [HttpPost]
        public async Task<IActionResult> Active(ApplicationUser user)
        {

            var userinfo = _db.ApplicationUser.FirstOrDefault(c => c.Id == user.Id);
            if (userinfo == null)
            {
                return NotFound();
            }
            userinfo.LockoutEnd = DateTime.Now.AddDays(-1);// To Active we use Less than today or Null Value asigne.
            int rowAffected = _db.SaveChanges();
            if (rowAffected > 0)
            {
                TempData["Edit"] = "User have been Active Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(userinfo);
        }


        // Delete Identity User

        public async Task<IActionResult> Delete(string id)
        {
            var user = _db.ApplicationUser.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }



        [HttpPost]
        public async Task<IActionResult> Delete(ApplicationUser user)
        {

            var userinfo = _db.ApplicationUser.FirstOrDefault(c => c.Id == user.Id);
            if (userinfo == null)
            {
                return NotFound();
            }
           _db.ApplicationUser.Remove(userinfo);
            int rowAffected = _db.SaveChanges();
            if (rowAffected > 0)
            {
                TempData["Delete"] = "User have been Delete Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(userinfo);
        }

    }
}
