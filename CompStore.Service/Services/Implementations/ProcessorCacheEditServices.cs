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
    public class ProcessorCacheEditServices : IProcessorCacheEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProcessorCacheEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task ProcessorCacheEdit(ProcessorCacheEditDto ProcessorCacheEdit)
        {
            if (ProcessorCacheEdit.Cache == 0)
                throw new ItemNotFoundException("Processor Cache  adı boş ola bilməz!");

            if (await _unitOfWork.ProcessorCacheRepository.IsExistAsync(x => x.Cache == ProcessorCacheEdit.Cache && x.Id != ProcessorCacheEdit.Id))
                throw new ItemNameAlreadyExists("Processor Cache  adı mövcuddur!");

            var lastProcessorCache  = await _unitOfWork.ProcessorCacheRepository.GetAsync(x => x.Id == ProcessorCacheEdit.Id);

            if (lastProcessorCache  == null)
                throw new ItemNotFoundException("Processor Cache  tapilmadı!");

            lastProcessorCache.Cache = ProcessorCacheEdit.Cache;
            lastProcessorCache.ModifiedDate = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task<ProcessorCacheEditDto> IsExists(int id)
        {
            var ProcessorCacheExist = await _unitOfWork.ProcessorCacheRepository.GetAsync(x => x.Id == id);
            if (ProcessorCacheExist == null)
                throw new Exception("ERROR");
            ProcessorCacheEditDto editDto = new ProcessorCacheEditDto
            {
                Cache = ProcessorCacheExist.Cache,
                Id = ProcessorCacheExist.Id,
            };
            return editDto;
        }

    }
}
