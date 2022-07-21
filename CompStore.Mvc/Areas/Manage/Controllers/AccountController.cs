using CompStore.Core.Entites;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos;
using CompStore.Service.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAdminLoginServices _adminLoginServices;

        public AccountController(UserManager<AppUser> userManager,  IAdminLoginServices adminLoginServices)
        {
            _userManager = userManager;
            _adminLoginServices = adminLoginServices;
        }
        public async Task<IActionResult> Login()
        {
            AppUser user = User.Identity.IsAuthenticated ? await _userManager.FindByNameAsync(User.Identity.Name) : null;

            if (user != null && user.IsAdmin == true)
            {
                return RedirectToAction("index", "dashboard");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginPostDto adminLoginPostDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _adminLoginServices.Login(adminLoginPostDto);
            }
            catch (UserNotFoundException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
          
            return RedirectToAction("index", "dashboard");
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> Logout()
        {
            _adminLoginServices.LogOut();
            return RedirectToAction("login", "account");
        }


        //public async Task<IActionResult> CreateRole()
        //{
        //    var role1 = await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        //    var role2 = await _roleManager.CreateAsync(new IdentityRole("Admin"));
        //    var role3 = await _roleManager.CreateAsync(new IdentityRole("Member"));

        //    AppUser SuperAdmin = new AppUser { FullName = "Super Admin", UserName = "SuperAdmin" };
        //    var admin = await _userManager.CreateAsync(SuperAdmin, "Admin123");
        //    var resultRole = await _userManager.AddToRoleAsync(SuperAdmin, "SuperAdmin");

        //    return Ok(resultRole);
        //}

    }
}
