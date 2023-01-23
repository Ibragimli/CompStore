using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.User
{
    public interface ISubscribeServices
    {
        public Task<bool> SubscribeCreate(string email);
    }
}
