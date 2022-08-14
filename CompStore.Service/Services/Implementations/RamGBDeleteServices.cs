using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class RamGBDeleteServices : IRamGBDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public RamGBDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task RamGBDelete(int id)
        {
            if (!await _unitOfWork.RamGBRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("RamGB tapilmadi");
            }

            if (await _unitOfWork.ProductParametrRepository.IsExistAsync(x => x.RamGBId == id))
            {
                throw new ItemUseException("Product Parametr model də istifade olunur deye silmek mümkün olmadı!");
            }

            var ramGB = await _unitOfWork.RamGBRepository.GetAsync(x => x.Id == id);
            _unitOfWork.RamGBRepository.Remove(ramGB);
            await _unitOfWork.CommitAsync();
        }
    }
}

