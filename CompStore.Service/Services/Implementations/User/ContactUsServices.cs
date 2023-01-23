using AutoMapper;
using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.User;
using CompStore.Service.Services.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.User
{
    public class ContactUsServices : IContactUsServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactUsServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateContactUs(ContactUsPostDto contactUsPostDto)
        {
            if (contactUsPostDto.ContactUs == null)
                throw new ItemNotFoundException("Xəta baş verdi!");


            await _unitOfWork.ContactUsRepository.InsertAsync(contactUsPostDto.ContactUs);
            await _unitOfWork.CommitAsync();
            return true;
        }


    }
}
