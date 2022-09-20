using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Data;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.Products;
using CompStore.Service.Helper;
using CompStore.Service.HelperService.Implementations;
using CompStore.Service.HelperService.Interfaces;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class ProductEditServices : ManageImageHelper, IProductEditServices
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageValue _key;
        private readonly DataContext _context;

        public ProductEditServices(IWebHostEnvironment env, IUnitOfWork unitOfWork, IImageValue key, DataContext context) : base(env, key)
        {
            _env = env;
            _unitOfWork = unitOfWork;
            _key = key;
            _context = context;
        }

        public void AddImages(Product product, Product productExist)
        {
            if (product.ImageFiles != null)
                _editImageSave(product, productExist);
        }

        public void AddPosterImage(Product product, Product productExist)
        {
            if (product.PosterImageFile != null)
            {
                PosterCheck(product);
                _editPosterImageSave(product, productExist);
            }
        }
        public void DeleteImages(Product product, Product productExist)
        {
            if (product.ProductImagesIds != null)
            {
                foreach (var item in productExist.ProductImages.Where(x => x.PosterStatus == false && !product.ProductImagesIds.Contains(x.Id)))
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/product", item.Image);
                }
                productExist.ProductImages.RemoveAll(x => x.PosterStatus == false && !product.ProductImagesIds.Contains(x.Id));
            }
            else
            {
                foreach (var item in productExist.ProductImages.Where(x => x.PosterStatus == false))
                {
                    if (productExist.ProductImages.Where(x => x.PosterStatus == false).Count() > 1)
                        DeleteFile(item.Image);
                }
                if (productExist.ProductImages.Where(x => x.PosterStatus == false).Count() > 1)
                    productExist.ProductImages.RemoveAll(x => x.PosterStatus == false);
                else throw new ImageCountException("Axırıncı şəkil silinə bilməz!");
            }
        }
        public async Task<bool> IsExistProduct(int id)
        {
            return await _unitOfWork.ProductRepository.IsExistAsync(x => x.Id == id);
        }
        public async Task<Product> ExistProduct(int id)
        {
            Product prd = await _context.Products.Include(x => x.ProductImages).Include(x => x.Model).Include(x => x.ProductParametr).ThenInclude(y => y.DaxiliYaddaş).Include(x => x.CategoryBrandId).FirstOrDefaultAsync(x => x.Id == id);
            return prd;
        }
        private void _editImageSave(Product product, Product productExist)
        {
            foreach (var image in product.ImageFiles)
            {
                if (image.ContentType != _key.ValueStr("ImageType1") && image.ContentType != _key.ValueStr("ImageType2")) continue;
                if (image.Length > _key.ValueInt("ImageSize") * 1048576) continue;
                ProductImage newImage = new ProductImage
                {
                    PosterStatus = false,
                    Image = FileManager.Save(_env.WebRootPath, "uploads/product", image),
                };
                if (productExist.ProductImages == null)
                {
                    productExist.ProductImages = new List<ProductImage>();
                }
                productExist.ProductImages.Add(newImage);
            }
        }
        private void _editPosterImageSave(Product product, Product productExist)
        {
            var posterFile = product.PosterImageFile;
            ProductImage posterImage = productExist.ProductImages.FirstOrDefault(x => x.PosterStatus == true);

            var filename = FileSave(product);
            DeleteFile(productExist.ProductImages.FirstOrDefault(x => x.PosterStatus == true).Image);
            posterImage.Image = filename;
        }

        public void CheckDaxiliYaddas(Product product, Product productExist)
        {
            if (product.ProductParametr.DaxiliYaddaş.IsHDD == false)
                productExist.ProductParametr.DaxiliYaddaş.HDDHecmId = null;
            if (product.ProductParametr.DaxiliYaddaş.IsSSD == false)
            {
                productExist.ProductParametr.DaxiliYaddaş.SSDHecmId = null;
                productExist.ProductParametr.DaxiliYaddaş.SSDTypeId = null;
            }
        }

        public async void SaveContext(Product product)
        {
            await _unitOfWork.CommitAsync();
        }
    }
}
