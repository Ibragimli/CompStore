using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.Products;
using CompStore.Service.Helper;
using CompStore.Service.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class ProductCreateServices : IProductCreateServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;

        public ProductCreateServices(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        public async Task<DaxiliYaddaş> CreateDY(CreatePostDto create)
        {
            DaxiliYaddaş daxiliYaddas = create.ProductParametr.DaxiliYaddaş;
            if (!daxiliYaddas.IsSSD) daxiliYaddas.SSDTypeId = null;
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

        public void ImagesCheck(Product Images)
        {
            foreach (var image in Images.ImageFiles)
            {
                if (image.ContentType != "image/png" && image.ContentType != "image/jpeg")
                    throw new ImageFormatException("Poster şekli yalnız (png ve ya jpg) type-ında ola biler");
                if (image.Length > 2097152)
                    throw new ImageFormatException("Poster şeklinin max yaddaşı 2MB ola biler!");
            }
        }

        public void PosterCheck(Product Image)
        {
            if (Image.PosterImageFile.ContentType != "image/png" && Image.PosterImageFile.ContentType != "image/jpeg")
                throw new ImageFormatException("Poster şekli yalnız (png ve ya jpg) type-ında ola biler");

            if (Image.PosterImageFile.Length > 2097152)
                throw new ImageFormatException("Poster şeklinin max yaddaşı 2MB ola biler!");
        }

        public void ProductUpdate(Product product, CreatePostDto create, ProductParametr parametr)
        {
            var brandCatId = _unitOfWork.CategoryBrandIdRepository.GetAsync(x => x.BrandId == create.CategoryBrand.BrandId && x.CategoryId == create.CategoryBrand.CategoryId);
            create.Product.ProductParametrId = parametr.Id;
            create.Product.ModelId = create.Model.Id;
            create.Product.CategoryBrandIdId = brandCatId.Id;
        }

        public async void SaveChange(Product product)
        {
            await _unitOfWork.ProductCreateRepository.InsertAsync(product);
        }

        private string FileSave(Product Image)
        {
            string image = FileManager.Save(_env.WebRootPath, "uploads/product", Image.PosterImageFile);
            return image; ;
        }
    }
}
