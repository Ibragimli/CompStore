﻿using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.ViewModels;
using CompStore.Service.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        //private readonly IEmailService _emailService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(DataContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager/*, IEmailService emailService*/, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            //_emailService = emailService;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Login()
        {
            AppUser user = User.Identity.IsAuthenticated ? await _userManager.FindByNameAsync(User.Identity.Name) : null;

            if (user != null && user.IsAdmin == false)
            {
                return RedirectToAction("index", "home");
            }
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AppUserDto user)
        {
            if (user.Password == null)
            {
                ModelState.AddModelError("", "Username və ya  Password  yanlışdır!");
                return View();
            }
            var UserExists = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == user.Username);
            if (UserExists == null)
            {
                ModelState.AddModelError("", "Username və ya Password yanlışdır!");
                return View();
            }
            if (!UserExists.IsAdmin)
            {

                var result = await _signInManager.PasswordSignInAsync(UserExists, user.Password, false, false);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Username və ya Password yanlışdır!");
                    return View();
                }



                var WishCookiesDelete = HttpContext.Request.Cookies["wishItemList"];
                if (WishCookiesDelete != null)
                {
                    var CookieDeleteJson = JsonConvert.DeserializeObject<List<WishItemViewModel>>(WishCookiesDelete);
                    foreach (var cookieItem in CookieDeleteJson)
                    {
                        WishItem wishItemAdd = new WishItem
                        {
                            AppUserId = UserExists.Id,
                            ProductId = cookieItem.ProductId
                        };
                        var productExist = _context.WishItems.Any(x => x.ProductId == wishItemAdd.ProductId);
                        if (!productExist)
                        {
                            _context.WishItems.Add(wishItemAdd);
                        }
                    }
                    HttpContext.Response.Cookies.Delete("wishItemList");
                    _context.SaveChanges();
                }
                return RedirectToAction("index", "home");
            }


            ModelState.AddModelError("", "Username və ya Password yanlışdır!");
            return View();
        }


        public async Task<IActionResult> Register()
        {
            AppUser user = User.Identity.IsAuthenticated ? await _userManager.FindByNameAsync(User.Identity.Name) : null;

            if (user != null && user.IsAdmin == false)
            {
                return RedirectToAction("index", "home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterDto user)
        {
            if (user.Password == null) ModelState.AddModelError("", "Password-u daxili edin!");

            if (user.ConfirmPassword == null) ModelState.AddModelError("", "ConfirmPassword-u daxili edin!");
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var userExistEmail = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == user.Email);
            if (userExistEmail != null)
            {
                ModelState.AddModelError("Email", "Email is Already!");
            }
            var userExistUsername = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == user.Username);
            if (userExistUsername != null)
            {
                ModelState.AddModelError("Username", "Username is Already!");
            }
            if (user.Password != user.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "ConfirmPassword is uncorrect!");
            }
            if (!ModelState.IsValid)
            {
                return View(user);
            }


            AppUser newUser = new AppUser
            {
                UserName = user.Username,
                Surname = user.Surname,
                Name = user.Name,
                Email = user.Email,
                IsAdmin = false,
                FullName = user.Name + " " + user.Surname,
            };

            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(newUser, "Member");
            await _signInManager.PasswordSignInAsync(newUser, user.Password, false, false);

            return RedirectToAction("index", "home");
        }
        //public async Task<IActionResult> ForgotPassword()
        //{
        //    AppUser user = User.Identity.IsAuthenticated ? await _userManager.FindByNameAsync(User.Identity.Name) : null;

        //    if (user != null && user.IsAdmin == false)
        //    {
        //        return RedirectToAction("index", "home");
        //    }
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ForgotPassword(ForgotViewModel forgotVM)
        //{
        //    //AppUser user = await _userManager.Users.FirstOrDefaultAsync(x => x.NormalizedEmail == forgotVM.Email.ToUpper());
        //    AppUser user = await _userManager.FindByEmailAsync(forgotVM.Email);
        //    if (user == null)
        //    {
        //        ModelState.AddModelError("email", "User not found!");
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        //    var url = Url.Action("resetpassword", "account", new { email = forgotVM.Email, token = token }, Request.Scheme);
        //    string body = string.Empty;

        //    using (StreamReader reader = new StreamReader("wwwroot/templates/resetpassword.html"))
        //    {
        //        body = reader.ReadToEnd();
        //    }

        //    body = body.Replace("{{url}}", url);
        //    _emailService.Send(forgotVM.Email, "ChangePassword", body);
        //    TempData["Success"] = "Email send!";
        //    return RedirectToAction("login", "account");
        //}

        //public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordVM)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("index", "home");
        //    }
        //    if (resetPasswordVM.Email == null)
        //    {
        //        return RedirectToAction("error", "error");
        //    }
        //    AppUser user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);
        //    if (user == null || !(await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetPasswordVM.Token)))
        //    {
        //        return RedirectToAction("login", "account");
        //    }
        //    return View(resetPasswordVM);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ChangePassword(ResetPasswordViewModel resetPasswordVM)
        //{
        //    if (string.IsNullOrWhiteSpace(resetPasswordVM.Password) || resetPasswordVM.Password.Length > 25)
        //        ModelState.AddModelError("Password", "Password is required and must be less than 25 character");
        //    if (!ModelState.IsValid)
        //    {
        //        return View("ResetPassword", resetPasswordVM);
        //    }
        //    AppUser user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);
        //    if (user == null)
        //    {
        //        return RedirectToAction("login", "account");
        //    }
        //    var result = await _userManager.ResetPasswordAsync(user, resetPasswordVM.Token, resetPasswordVM.Password);
        //    if (!result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }
        //        return View("ResetPassword", resetPasswordVM);
        //    }
        //    TempData["Success"] = "Password change is successfull!";

        //    return RedirectToAction("login", "account");
        //}

        //[Authorize(Roles = "Member")]
        //public async Task<IActionResult> Profile()
        //{
        //    AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
        //    if (user == null)
        //    {
        //        return RedirectToAction("Error", "error");
        //    }
        //    MemberProfileViewModel memberProfile = new MemberProfileViewModel
        //    {
        //        ProfileUpdateViewModel = new ProfileUpdateViewModel
        //        {
        //            Fullname = user.FullName,
        //            Username = user.UserName,
        //            Email = user.Email,
        //        },
        //        Orders = _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Product).Where(x => x.AppUserId == user.Id).ToList(),
        //        LabTests = _context.LabTests.Include(x => x.LabTestPrice).Where(x => x.AppUserId == user.Id).ToList(),
        //    };

        //    return View(memberProfile);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Profile(ProfileUpdateViewModel profileUpdateVM)
        //{
        //    AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
        //    MemberProfileViewModel memberProfile = new MemberProfileViewModel
        //    {
        //        ProfileUpdateViewModel = profileUpdateVM,
        //    };
        //    if (user == null)
        //    {
        //        return View(memberProfile);
        //    }

        //    if (user.Email != profileUpdateVM.Email && _userManager.Users.Any(x => x.NormalizedEmail == profileUpdateVM.Email.ToUpper()))
        //    {
        //        ModelState.AddModelError("email", "Email is already");
        //    }
        //    if (user.UserName != profileUpdateVM.Username && await _userManager.Users.AnyAsync(x => x.NormalizedUserName == profileUpdateVM.Username.ToUpper()))
        //    {
        //        ModelState.AddModelError("Username", "Username is already");
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        return View(memberProfile);
        //    }

        //    if (!string.IsNullOrWhiteSpace(profileUpdateVM.ConfirmPassword) && !string.IsNullOrWhiteSpace(profileUpdateVM.NewPassword))
        //    {
        //        var resultPassword = await _userManager.ChangePasswordAsync(user, profileUpdateVM.CurrentPassword, profileUpdateVM.NewPassword);
        //        if (!resultPassword.Succeeded)
        //        {
        //            foreach (var error in resultPassword.Errors)
        //            {
        //                ModelState.AddModelError("", error.Description);
        //            }
        //            return View(memberProfile);
        //        }
        //    }
        //    user.Email = profileUpdateVM.Email;
        //    user.FullName = profileUpdateVM.Fullname;
        //    user.UserName = profileUpdateVM.Username;
        //    user.PhoneNumber = profileUpdateVM.PhoneNumber;

        //    await _userManager.UpdateAsync(user);
        //    await _signInManager.SignInAsync(user, true);
        //    return RedirectToAction("profile", "account");
        //}


        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }
    }
}
