﻿using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.ProcessorModels;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
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

            if (await _unitOfWork.ProcessorModelRepository.IsExistAsync(x => x.Name == ProcessorModelEdit.Name && x.Id != ProcessorModelEdit.Id))
                throw new ItemNameAlreadyExists("Processor Model  adı mövcuddur!");

            var lastProcessorModel = await _unitOfWork.ProcessorModelRepository.GetAsync(x => x.Id == ProcessorModelEdit.Id);

            if (lastProcessorModel == null)
                throw new ItemNotFoundException("Processor Model  tapilmadı!");

            lastProcessorModel.Name = ProcessorModelEdit.Name;
            lastProcessorModel.ModifiedDate = DateTime.UtcNow.AddHours(4);

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
