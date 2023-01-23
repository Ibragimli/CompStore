using CompStore.Service.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.User
{
    public interface IContactUsServices
    {
        public Task<bool> CreateContactUs(ContactUsPostDto contactUsPostDto);
    }
}
