using AutoMapper;
using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.Brands;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class BrandCreateServices : IBrandCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandCreateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateBrand(BrandCreateDto brandDto)
        {
            if (brandDto.Brand.Name == null)
                throw new ItemNotFoundException("Brand adı boş ola bilməz!");
            if (await _unitOfWork.BrandRepository.IsExistAsync(x => x.Name.ToLower() == brandDto.Brand.Name.ToLower()))
                throw new ItemNameAlreadyExists("Brand adı mövcuddur!");

            await _unitOfWork.BrandRepository.InsertAsync(brandDto.Brand);
            await _unitOfWork.CommitAsync();
        }

    }
}

