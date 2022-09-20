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
    public class ProcessorCacheDeleteServices : IProcessorCacheDeleteServices
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProcessorCacheDeleteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ProcessorCacheDelete(int id)
        {
            if (!await _unitOfWork.ProcessorCacheRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("ProcessorCache tapilmadi");
            }

            if (await _unitOfWork.ProductParametrRepository.IsExistAsync(x => x.ProcessorCacheId == id))
            {
                throw new ItemUseException("Product Parametr model də istifade olunur deye silmek mümkün olmadı!");
            }

            var ProcessorCache = await _unitOfWork.ProcessorCacheRepository.GetAsync(x => x.Id == id);
            _unitOfWork.ProcessorCacheRepository.Remove(ProcessorCache);
            await _unitOfWork.CommitAsync();
        }
    }
}
