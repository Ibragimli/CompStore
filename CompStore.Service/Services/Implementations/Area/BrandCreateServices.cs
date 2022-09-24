using AutoMapper;
using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.Brands;
using CompStore.Service.HelperService.Interfaces;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class BrandCreateServices : IBrandCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBrandImageHelper _brandImageHelper;

        public BrandCreateServices(IUnitOfWork unitOfWork, IBrandImageHelper brandImageHelper)
        {
            _unitOfWork = unitOfWork;
            _brandImageHelper = brandImageHelper;
        }

        public async Task CreateBrand(BrandCreateDto brandDto)
        {
            if (brandDto.Brand.Name == null)
                throw new ItemNotFoundException("Brand adı boş ola bilməz!");
            if (await _unitOfWork.BrandRepository.IsExistAsync(x => x.Name.ToLower() == brandDto.Brand.Name.ToLower()))
                throw new ItemNameAlreadyExists("Brand adı mövcuddur!");

            if (brandDto.Brand.BrandImageFile != null)
            {
                _brandImageHelper.ImageCheck(brandDto.Brand);
                brandDto.Brand.BrandImage = _brandImageHelper.FileSave(brandDto.Brand);
            }

            await _unitOfWork.BrandRepository.InsertAsync(brandDto.Brand);
            await _unitOfWork.CommitAsync();
        }

    }
}

