using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.Products;
using CompStore.Service.Helper;
using CompStore.Service.HelperService.Implementations;
using CompStore.Service.HelperService.Interfaces;
using CompStore.Service.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class ProductCreateServices : ManageImageHelper, IProductCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        private readonly IImageValue _key;

        public ProductCreateServices(IUnitOfWork unitOfWork, IWebHostEnvironment env, IImageValue key) : base(env, key)
        {
            _unitOfWork = unitOfWork;
            _env = env;
            _key = key;
        }

      

        public async Task<DaxiliYaddaş> CreateDY(CreatePostDto create)
        {

            DaxiliYaddaş daxiliYaddas = create.ProductParametr.DaxiliYaddaş;
            if (daxiliYaddas.IsHDD == false && daxiliYaddas.IsSSD == false)
                throw new FileFormatException("Daxili yaddaşdan ən azı birini qeyd etməlisiz!");
            if (!daxiliYaddas.IsSSD) daxiliYaddas.SSDTypeId = null;
            if (!daxiliYaddas.IsSSD) daxiliYaddas.SSDHecmId = null;
            if (!daxiliYaddas.IsHDD) daxiliYaddas.HDDHecmId = null;
            await _unitOfWork.DaxiliYaddasRepository.InsertAsync(daxiliYaddas);
            await _unitOfWork.CommitAsync();
            return daxiliYaddas;
        }
        public async void CreateImage(Product Image, bool value)
        {
            ProductImage Posterimage = new ProductImage
            {
                PosterStatus = value,
                Product = Image,
                Image = FileSave(Image),
            };
            await _unitOfWork.ProductImagesRepositroy.InsertAsync(Posterimage);
        }
        public async Task<ProductParametr> CreatePP(CreatePostDto create, DaxiliYaddaş daxiliYaddaş)
        {
            var parametr = create.ProductParametr;
            parametr.DaxiliYaddaşId = daxiliYaddaş.Id;
            await _unitOfWork.ProductParametrRepository.InsertAsync(parametr);
            await _unitOfWork.CommitAsync();
            return parametr;
        }
        public void ProductUpdate(Product product, CreatePostDto create, ProductParametr parametr)
        {
            var brandCatId = _unitOfWork.CategoryBrandIdRepository.GetAsync(x => x.BrandId == create.CategoryBrand.BrandId && x.CategoryId == create.CategoryBrand.CategoryId);
            create.Product.ProductParametrId = parametr.Id;
            create.Product.CategoryBrandIdId = brandCatId.Id;
        }
        public async void SaveChange(Product product)
        {
            await _unitOfWork.ProductCreateRepository.InsertAsync(product);
        }
    }
}
