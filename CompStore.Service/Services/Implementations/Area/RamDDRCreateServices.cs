using AutoMapper;
using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.RamDDRs;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class RamDDRCreateServices : IRamDDRCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public RamDDRCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateDDR(RamDDRCreateDto brandDto)
        {
            if (brandDto.RamDDR.DDR == null)
                throw new ItemNotFoundException("RamDDR adı boş ola bilməz!");
            if (await _unitOfWork.RamDDRRepository.IsExistAsync(x => x.DDR.ToLower() == brandDto.RamDDR.DDR.ToLower()))
                throw new ItemNameAlreadyExists("RamDDR adı mövcuddur!");

            await _unitOfWork.RamDDRRepository.InsertAsync(brandDto.RamDDR);
            await _unitOfWork.CommitAsync();
        }

    }
}

