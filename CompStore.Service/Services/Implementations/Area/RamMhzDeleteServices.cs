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
    
    public class RamMhzDeleteServices : IRamMhzDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public RamMhzDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task RamMhzDelete(int id)
        {
            if (!await _unitOfWork.RamMhzRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("RamMhz tapilmadi");
            }

            if (await _unitOfWork.ProductParametrRepository.IsExistAsync(x => x.RamMhzId == id))
            {
                throw new ItemUseException("Product Parametr model də istifade olunur deye silmek mümkün olmadı!");
            }

            var ramMhz = await _unitOfWork.RamMhzRepository.GetAsync(x => x.Id == id);
            _unitOfWork.RamMhzRepository.Remove(ramMhz);
            await _unitOfWork.CommitAsync();
        }
    }
}
