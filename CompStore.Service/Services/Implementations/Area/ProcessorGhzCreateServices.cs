using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.ProcessorGhzs;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class ProcessorGhzCreateServices : IProcessorGhzCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProcessorGhzCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateGhz(ProcessorGhzCreateDto processorGhzDto)
        {
            {
                if (processorGhzDto.ProcessorGhz.Ghz == 0)
                    throw new ItemNotFoundException("ProcessorGhz adı boş ola bilməz!");
                if (await _unitOfWork.ProcessorGhzRepository.IsExistAsync(x => x.Ghz == processorGhzDto.ProcessorGhz.Ghz))
                    throw new ItemNameAlreadyExists("ProcessorGhz adı mövcuddur!");

                await _unitOfWork.ProcessorGhzRepository.InsertAsync(processorGhzDto.ProcessorGhz);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
