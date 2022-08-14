using AutoMapper;
using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.RamDDRs;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class RamDDRCreateServices : IRamDDRCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public RamDDRCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateBrand(RamDDRCreateDto brandDto)
        {
            if (brandDto.RamDDR.DDR == null)
                throw new ItemNotFoundException("RamDDR adı boş ola bilməz!");
            if (await _unitOfWork.BrandRepository.IsExistAsync(x => x.Name.ToLower() == brandDto.RamDDR.DDR.ToLower()))
                throw new ItemNameAlreadyExists("RamDDR adı mövcuddur!");

            await _unitOfWork.RamDDRRepository.InsertAsync(brandDto.RamDDR);
            await _unitOfWork.CommitAsync();
        }

    }
}

