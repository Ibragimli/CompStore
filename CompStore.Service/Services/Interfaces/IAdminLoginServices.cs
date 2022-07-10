using CompStore.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IAdminLoginServices
    {
        Task<bool> Login(AdminLoginPostDto adminLoginPostDto);
        void LogOut();
    }
}
