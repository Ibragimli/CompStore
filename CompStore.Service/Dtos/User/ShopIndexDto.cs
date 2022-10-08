using CompStore.Core.Entites;
using CompStore.Service.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.User
{

    public class ShopIndexDto
    {
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public PagenatedListDto<Product> PagenatedProducts { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<CategoryBrandId> CategoryBrandIds { get; set; }
        public ShopPostDto ShopPostDto { get; set; }

    }
    public class ShopPostDto
    {
        public Brand BrandId { get; set; }

    }
}
