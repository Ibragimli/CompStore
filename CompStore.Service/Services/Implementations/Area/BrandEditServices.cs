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
    public class BrandEditServices : IBrandEditServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBrandImageHelper _brandImageHelper;

        public BrandEditServices(IUnitOfWork unitOfWork, IBrandImageHelper brandImageHelper)
        {
            _unitOfWork = unitOfWork;
            _brandImageHelper = brandImageHelper;
        }

        public async Task BrandEdit(BrandEditDto brandEdit)
        {
            if (brandEdit.Brand.Name == null)
                throw new ItemNotFoundException("Brand adı boş ola bilməz!");

            if (await _unitOfWork.BrandRepository.IsExistAsync(x => x.Name.ToLower() == brandEdit.Brand.Name.ToLower() && x.Id != brandEdit.Brand.Id))
                throw new ItemNameAlreadyExists("Brand adı mövcuddur!");

            var lastBrand = await _unitOfWork.BrandRepository.GetAsync(x => x.Id == brandEdit.Brand.Id);

            if (lastBrand == null)
                throw new ItemNotFoundException("Brand tapilmadı!");

            lastBrand.Name = brandEdit.Brand.Name;
            if (brandEdit.Brand.BrandImageFile != null)
            {
                _brandImageHelper.ImageCheck(brandEdit.Brand);
                _brandImageHelper.DeleteFile(lastBrand.BrandImage);
                lastBrand.BrandImage = _brandImageHelper.FileSave(brandEdit.Brand);

            }
            lastBrand.ModifiedDate = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task<BrandEditDto> IsExists(int id)
        {
            var brandExist = await _unitOfWork.BrandRepository.GetAsync(x => x.Id == id);
            if (brandExist == null)
                throw new Exception("ERROR");
            BrandEditDto editDto = new BrandEditDto
            {
                Brand = brandExist,
            };
            return editDto;
        }
    }
}
