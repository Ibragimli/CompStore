﻿using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class AdminLoginServices : IAdminLoginServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AdminLoginServices(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> Login(AdminLoginPostDto adminLoginPostDto)
        {
            AppUser adminExist = await _unitOfWork.AdminAccountRepository.GetAsync(x => x.UserName == adminLoginPostDto.Username);

            if (adminExist != null && adminExist.IsAdmin == true)
            {
                var result = await _signInManager.PasswordSignInAsync(adminExist, adminLoginPostDto.Password, false, false);
                if (!result.Succeeded) throw new UserNotFoundException("Username və ya Passoword yanlışdır!");
              
                return true;
            }
            throw new UserNotFoundException("Username və ya Passoword yanlışdır!");
        }


        public async void LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
