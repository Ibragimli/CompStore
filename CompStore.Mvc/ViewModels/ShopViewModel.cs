using CompStore.Core.Entites;
using CompStore.Service.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.ViewModels
{
    public class ShopViewModel
    {
        public List<Brand> Brands { get; set; }
        public List<Product> Products { get; set; }
        public PagenetedList<Product> PagenatedProducts { get; set; }

        public List<Category> Categories { get; set; }
        public List<CategoryBrandId> CategoryBrandIds { get; set; }
        public ShopPostViewModel ShopPostVM { get; set; }

        public int categoryId { get; set; }
        public int brandId { get; set; }

    }
    public class ShopPostViewModel
    {
        public Brand BrandId { get; set; }

    }
}
