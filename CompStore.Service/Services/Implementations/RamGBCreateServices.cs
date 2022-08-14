using AutoMapper;
using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.RamGbs;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class RamGBCreateServices : IRamGBCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public RamGBCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateGB(RamGBCreateDto brandDto)
        {
            if (brandDto.RamGB.GB == 0)
                throw new ItemNotFoundException("RamGB adı boş ola bilməz!");
            if (await _unitOfWork.RamGBRepository.IsExistAsync(x => x.GB == brandDto.RamGB.GB))
                throw new ItemNameAlreadyExists("RamGB adı mövcuddur!");

            await _unitOfWork.RamGBRepository.InsertAsync(brandDto.RamGB);
            await _unitOfWork.CommitAsync();
        }

    }
}

