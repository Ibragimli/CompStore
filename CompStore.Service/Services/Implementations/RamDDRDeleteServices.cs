using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class RamDDRDeleteServices : IRamDDRDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public RamDDRDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task RamDDRDelete(int id)
        {
            if (!await _unitOfWork.RamDDRRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("RamDDR tapilmadi");
            }

            if (await _unitOfWork.ProductParametrRepository.IsExistAsync(x => x.RamDDRId == id))
            {
                throw new ItemUseException("Product Parametr model də istifade olunur deye silmek mümkün olmadı!");
            }

            var ramDDR = await _unitOfWork.RamDDRRepository.GetAsync(x => x.Id == id);
            _unitOfWork.RamDDRRepository.Remove(ramDDR);
            await _unitOfWork.CommitAsync();
        }
    }
}

