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
    public class SSDTypeDeleteServices : ISSDTypeDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public SSDTypeDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SSDTypeDelete(int id)
        {
            if (!await _unitOfWork.SSDTypeRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("SSDType tapilmadi");
            }

            if (await _unitOfWork.DaxiliYaddasRepository.IsExistAsync(x => x.SSDTypeId == id))
            {
                throw new ItemUseException("Daxili Yaddaş modelində istifade olunur deye silmek mümkün olmadı!");
            }

            var SSDType = await _unitOfWork.SSDTypeRepository.GetAsync(x => x.Id == id);
            _unitOfWork.SSDTypeRepository.Remove(SSDType);
            await _unitOfWork.CommitAsync();
        }
    }
}
