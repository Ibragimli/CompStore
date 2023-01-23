using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{

    public class ContactUsIndexServices : IContactUsIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public ContactUsIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<ContactUs>> SearchCheck(string search)
        {
            var ContactUsLast = _unitOfWork.ContactUsRepository.asQueryable();

            var ContactUs = _unitOfWork.ContactUsRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await ContactUs.IsExistAsync(x => x.Email.ToLower() == search);
                if (nameSearch)
                    ContactUsLast = ContactUsLast.Where(x => x.Email.ToLower().Contains(search));
            }
            return ContactUsLast;
        }

    }

}
