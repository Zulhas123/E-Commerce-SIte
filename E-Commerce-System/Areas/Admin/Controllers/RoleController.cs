using E_Commerce_System.Areas.Admin.ViewModel;
using E_Commerce_System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        UserManager<IdentityUser> _userManager;
        RoleManager<IdentityRole> _roleManager; // for Identity
        ApplicationDbContext _db;
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }
         
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            ViewBag.Roles = roles;
            return View(roles);
        }


        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            IdentityRole role = new IdentityRole();
            role.Name = name;
            var isExist = await _roleManager.RoleExistsAsync(role.Name);
            if (isExist)
            {
                ViewBag.msg = "This Role is already Exist";
                ViewBag.Name = name;
                return View();
            }
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                TempData["Save"] = "Role have been Save Successfully";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        // Edi Action

        public async Task<IActionResult> Edit( string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if(role== null)
            {
                return NotFound();
            }
            ViewBag.id = role.Id;
            ViewBag.name = role.Name;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, string name)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            role.Name = name;
            var isExist = await _roleManager.RoleExistsAsync(role.Name);
            if (isExist)
            {
                ViewBag.msg = "This Role is already Exist";
                ViewBag.Name = name;
                return View();
            }
            role.Name = name;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                TempData["Edit"] = "Role have been Update Successfully";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            ViewBag.id = role.Id;
            ViewBag.name = role.Name;
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                TempData["Delete"] = "Role have been Delete Successfully";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.id = role.Id;
            ViewBag.name = role.Name;
            return View();
        }


        public async Task<IActionResult>Assign()
        {
            ViewBag.UserId = new SelectList(_db.ApplicationUser.Where(c=>c.LockoutEnd<DateTime.Now || c.LockoutEnd==null) .ToList(),"Id", "UserName");
            ViewBag.RoleId = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Assign(UserRoleVM userRole)

        {
            var user = _db.ApplicationUser.FirstOrDefault(c => c.Id == userRole.UserId);
            // IdentityRole role = new IdentityRole();

            var isExist = await _userManager.IsInRoleAsync(user, userRole.RoleId); // Here need to Check IsExist Role

            if (isExist)
            {
                ViewBag.msg = " This User already assign this role";
                ViewBag.UserId = new SelectList(_db.ApplicationUser.Where(c => c.LockoutEnd < DateTime.Now || c.LockoutEnd == null).ToList(), "Id", "UserName");
                ViewBag.RoleId = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
                return View();
            }
            var role = await _userManager.AddToRoleAsync(user, userRole.RoleId);
            if (role.Succeeded)
            {
                TempData["Save"] = "User Role have been Assign Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult AssignUserRole()
        {
            var result = from ur in _db.UserRoles
                         join r in _db.Roles on ur.RoleId equals r.Id
                         join a in _db.ApplicationUser on ur.UserId equals a.Id
                         select new UserRoleMappingVM()
                         {
                             UserId = ur.UserId,
                             RoleId = ur.RoleId,
                             UserName = a.UserName,
                             RoleName = r.Name

                         };
            ViewBag.UserRoles = result;

            return View();
        }


    }
}
