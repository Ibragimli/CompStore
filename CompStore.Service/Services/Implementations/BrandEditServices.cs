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
    public class BrandEditServices : IBrandEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task BrandEdit(BrandEditDto brandEdit)
        {
            if (brandEdit.Name == null)
                throw new ItemNotFoundException("Brand adı boş ola bilməz!");

            if (await _unitOfWork.BrandRepository.IsExistAsync(x => x.Name.ToLower() == brandEdit.Name.ToLower()))
                throw new ItemNameAlreadyExists("Brand adı mövcuddur!");

            var lastBrand = await _unitOfWork.BrandRepository.GetAsync(x => x.Id == brandEdit.Id);

            if (lastBrand == null)
                throw new ItemNotFoundException("Brand tapilmadı!");

            lastBrand.Name = brandEdit.Name;

            await _unitOfWork.CommitAsync();
        }

        public async Task<BrandEditDto> IsExists(int id)
        {
            var brandExist = await _unitOfWork.BrandRepository.GetAsync(x => x.Id == id);
            if (brandExist == null)
                throw new Exception("ERROR");
            BrandEditDto editDto = new BrandEditDto
            {
                Name = brandExist.Name,
                Id = brandExist.Id,
            };
            return editDto;
        }
    }
}
