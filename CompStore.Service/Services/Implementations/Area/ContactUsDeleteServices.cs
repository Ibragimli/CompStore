using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class ContactUsDeleteServices : IContactUsDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactUsDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ContactUsDelete(int id)
        {
            if (!await _unitOfWork.ContactUsRepository.IsExistAsync(x => x.Id == id)) throw new ItemNotFoundException("ContactUs tapilmadi");

            var ContactUs = await _unitOfWork.ContactUsRepository.GetAsync(x => x.Id == id);

            _unitOfWork.ContactUsRepository.Remove(ContactUs);
            await _unitOfWork.CommitAsync();
        }
    }
}
