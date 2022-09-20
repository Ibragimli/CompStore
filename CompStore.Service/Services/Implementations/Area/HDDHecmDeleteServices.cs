using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
 
    public class HDDHecmDeleteServices : IHDDHecmDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public HDDHecmDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HDDHecmDelete(int id)
        {
            if (!await _unitOfWork.HDDHecmsRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("HDDHecm tapilmadi");
            }

            if (await _unitOfWork.DaxiliYaddasRepository.IsExistAsync(x => x.HDDHecmId == id))
            {
                throw new ItemUseException("Daxili Yaddaş modelində istifade olunur deye silmek mümkün olmadı!");
            }

            var HDDHecm = await _unitOfWork.HDDHecmsRepository.GetAsync(x => x.Id == id);
            _unitOfWork.HDDHecmsRepository.Remove(HDDHecm);
            await _unitOfWork.CommitAsync();
        }
    }
}
