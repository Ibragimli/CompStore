using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Data;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Helper;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class ProductDeleteServices : IProductDeleteServices
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;

        public ProductDeleteServices(IWebHostEnvironment env, IUnitOfWork unitOfWork)
        {
            _env = env;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> DaxiliYaddasDelete(Product product)
        {
            DaxiliYaddaş daxiliYaddasExist = await _unitOfWork.DaxiliYaddasRepository.GetAsync(x => x.Id == product.ProductParametr.DaxiliYaddaşId);
            if (daxiliYaddasExist == null)
                return false;
            _unitOfWork.DaxiliYaddasRepository.Remove(daxiliYaddasExist);
            return true;
        }
        public void ImagesDelete(Product product)
        {
            var Images = product.ProductImages.Find(x => x.PosterStatus == false);
            foreach (var item in product.ProductImages.FindAll(x => x.PosterStatus == false))
            {
                FileManager.Delete(_env.WebRootPath, "uploads/product", item.Image);
                _unitOfWork.ProductImagesRepositroy.Remove(item);
            }
        }
        public void PosterImageDelete(Product product)
        {
            var PosterImage = product.ProductImages.Find(x => x.PosterStatus == true);
            FileManager.Delete(_env.WebRootPath, "uploads/product", PosterImage.Image);
            _unitOfWork.ProductImagesRepositroy.Remove(PosterImage);
        }
        public void ProductDelete(Product product)
        {
            _unitOfWork.ProductRepository.Remove(product);
        }
        public async Task<bool> ProductParametrDelete(Product product)
        {
            ProductParametr productParametrExist = await _unitOfWork.ProductParametrRepository.GetAsync(x => x.Id == product.ProductParametr.Id);
            if (productParametrExist == null)
                return false;
            _unitOfWork.ProductParametrRepository.Remove(productParametrExist);
            return true;
        }
    }
}
