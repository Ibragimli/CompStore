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
    public class ProcessorModelEditServices : IProcessorModelEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProcessorModelEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task ProcessorModelEdit(ProcessorModelEditDto ProcessorModelEdit)
        {
            if (ProcessorModelEdit.Name == null)
                throw new ItemNotFoundException("Processor Model  adı boş ola bilməz!");

            if (await _unitOfWork.ProcessorModelRepository.IsExistAsync(x => x.Name == ProcessorModelEdit.Name))
                throw new ItemNameAlreadyExists("Processor Model  adı mövcuddur!");

            var lastProcessorModel = await _unitOfWork.ProcessorModelRepository.GetAsync(x => x.Id == ProcessorModelEdit.Id);

            if (lastProcessorModel == null)
                throw new ItemNotFoundException("Processor Model  tapilmadı!");

            lastProcessorModel.Name = ProcessorModelEdit.Name;

            await _unitOfWork.CommitAsync();
        }

        public async Task<ProcessorModelEditDto> IsExists(int id)
        {
            var ProcessorModelExist = await _unitOfWork.ProcessorModelRepository.GetAsync(x => x.Id == id);
            if (ProcessorModelExist == null)
                throw new Exception("ERROR");
            ProcessorModelEditDto editDto = new ProcessorModelEditDto
            {
                Name = ProcessorModelExist.Name,
                Id = ProcessorModelExist.Id,
            };
            return editDto;
        }

    }

}
