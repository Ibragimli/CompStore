using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class SSDHecmDeleteServices : ISSDHecmDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public SSDHecmDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SSDHecmDelete(int id)
        {
            if (!await _unitOfWork.SSDHecmRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("SSDHecm tapilmadi");
            }

            if (await _unitOfWork.DaxiliYaddasRepository.IsExistAsync(x => x.SSDHecmId == id))
            {
                throw new ItemUseException("Daxili Yaddaş modelində istifade olunur deye silmek mümkün olmadı!");
            }

            var SSDHecm = await _unitOfWork.SSDHecmRepository.GetAsync(x => x.Id == id);
            _unitOfWork.SSDHecmRepository.Remove(SSDHecm);
            await _unitOfWork.CommitAsync();
        }
    }
}
