using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class ProductIndexServices : IProductIndexServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductIndexServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IQueryable<Product>> SearchCheck(string search)
        {
            var productLast = _unitOfWork.ProductRepository.asQueryableProduct();

            var product = _unitOfWork.ProductRepository;
            if (search != null)
            {
                search = search.ToLower();
                //categorySearch
                bool nameSearch = await product.IsExistAsync(x => x.Name.ToLower() == search);
                if (nameSearch)
                    productLast = productLast.Where(x => x.Name.ToLower().Contains(search));

                //categorySearch
                bool categorySearch = await product.IsExistAsync(x => x.CategoryBrandId.Category.Name.ToLower() == search);
                if (categorySearch)
                    productLast = productLast.Where(x => x.CategoryBrandId.Category.Name.ToLower().Contains(search));

                //brandSearch
                bool brandSearch = await product.IsExistAsync(x => x.CategoryBrandId.Brand.Name.ToLower() == search);
                if (brandSearch)
                    productLast = productLast.Where(x => x.CategoryBrandId.Brand.Name.ToLower().Contains(search));

                //modelSearch
                bool modelSearch = await product.IsExistAsync(x => x.Model.Name.ToLower() == search);
                if (modelSearch)
                    productLast = productLast.Where(x => x.Model.Name.ToLower().Contains(search));
            }
            return productLast;
        }
    }
}
