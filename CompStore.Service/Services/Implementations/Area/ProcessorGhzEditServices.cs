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
    public class ProcessorGhzEditServices : IProcessorGhzEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProcessorGhzEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task ProcessorGhzEdit(ProcessorGhzEditDto ProcessorGhzEdit)
        {
            if (ProcessorGhzEdit.Ghz == 0)
                throw new ItemNotFoundException("Processor Ghz  adı boş ola bilməz!");

            if (await _unitOfWork.ProcessorGhzRepository.IsExistAsync(x => x.Ghz == ProcessorGhzEdit.Ghz && x.Id != ProcessorGhzEdit.Id))
                throw new ItemNameAlreadyExists("Processor Ghz  adı mövcuddur!");

            var lastProcessorGhz = await _unitOfWork.ProcessorGhzRepository.GetAsync(x => x.Id == ProcessorGhzEdit.Id);

            if (lastProcessorGhz == null)
                throw new ItemNotFoundException("Processor Ghz  tapilmadı!");

            lastProcessorGhz.Ghz = ProcessorGhzEdit.Ghz;
            lastProcessorGhz.ModifiedDate = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task<ProcessorGhzEditDto> IsExists(int id)
        {
            var ProcessorGhzExist = await _unitOfWork.ProcessorGhzRepository.GetAsync(x => x.Id == id);
            if (ProcessorGhzExist == null)
                throw new Exception("ERROR");
            ProcessorGhzEditDto editDto = new ProcessorGhzEditDto
            {
                Ghz = ProcessorGhzExist.Ghz,
                Id = ProcessorGhzExist.Id,
            };
            return editDto;
        }

    }

}
