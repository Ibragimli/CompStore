using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.Dtos;
using CompStore.Service.Dtos.User;
using CompStore.Service.Services.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.User
{
    public class ProductShopIndexServices : IProductShopIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductShopIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //public async Task<Product> ProductCreate(int? brandId = null)
        //{
        //    var products = _unitOfWork.ProductRepository.asQueryable("CategoryBrandId.Category", "CategoryBrandId.Brand", "ProductImages");

        //    if (brandId != null)
        //    {
        //        products = products.(x => x.CategoryBrandId.BrandId == brandId.Value);
        //    }
        //    products.
        //    return products;
        //}

        public async Task<ShopIndexDto> ShopCreateViewModel(int pageIndex = 1, int pageSize = 12)
        {
            var product = new List<Product>();

            int totalCount = await _unitOfWork.ProductRepository.GetTotalCountAsync(x => x.IsDelete == false);

            ShopIndexDto shopVM = new ShopIndexDto
            {
                //Brands = await _unitOfWork.BrandRepository.GetAllAsync(x => x.IsDelete == false).ToList(),
                Categories = await _unitOfWork.CategoryRepository.GetAllAsync(x => x.IsDelete == false),
                CategoryBrandIds = await _unitOfWork.CategoryBrandIdRepository.GetAllAsync(x => x.IsDelete == false, "Category", "Brand"),
                //PagenatedProducts = PagenetedList<Product>.Create(products, page, 16),
                PagenatedProducts = new PagenatedListDto<Product>(product, totalCount, pageIndex, pageSize),
            };
            return shopVM;
        }

        Task<Product> IProductShopIndexServices.ProductCreate()
        {
            throw new NotImplementedException();
        }

        
    }
}
