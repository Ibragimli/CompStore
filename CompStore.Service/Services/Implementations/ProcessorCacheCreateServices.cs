using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.ProcessorCaches;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class ProcessorCacheCreateServices : IProcessorCacheCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProcessorCacheCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateCache(ProcessorCacheCreateDto processorCacheDto)
        {
            {
                if (processorCacheDto.ProcessorCache.Cache == 0)
                    throw new ItemNotFoundException("ProcessorCache adı boş ola bilməz!");
                if (await _unitOfWork.ProcessorCacheRepository.IsExistAsync(x => x.Cache == processorCacheDto.ProcessorCache.Cache))
                    throw new ItemNameAlreadyExists("ProcessorCache adı mövcuddur!");

                await _unitOfWork.ProcessorCacheRepository.InsertAsync(processorCacheDto.ProcessorCache);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
