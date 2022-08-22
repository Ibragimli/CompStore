using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.ProcessorModels;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class ProcessorModelCreateServices : IProcessorModelCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProcessorModelCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateModel(ProcessorModelCreateDto processorModelDto)
        {
            {
                if (processorModelDto.ProcessorModel.Name == null)
                    throw new ItemNotFoundException("ProcessorModel adı boş ola bilməz!");
                if (await _unitOfWork.ProcessorModelRepository.IsExistAsync(x => x.Name == processorModelDto.ProcessorModel.Name))
                    throw new ItemNameAlreadyExists("ProcessorModel adı mövcuddur!");

                await _unitOfWork.ProcessorModelRepository.InsertAsync(processorModelDto.ProcessorModel);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
