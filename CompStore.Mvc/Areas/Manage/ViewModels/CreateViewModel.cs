using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CompStore.Mvc.Areas.Manage.Controllers.ProductController;

namespace CompStore.Mvc.Areas.Manage.ViewModels
{
    public class CreateViewModel
    {
        public Product Product { get; set; }
        public List<CategoryBrandId> CategoryBrandIds { get; set; }
        public CategoryBrandId CategoryBrand { get; set; }
        public ProductParametr ProductParametr { get; set; }
        public EditCreateViewModel viewModel { get; set; }
    }
    public class CreatePostViewModel
    {
        public Product Product { get; set; }
        public ProductParametr ProductParametr { get; set; }
        public CategoryBrandId CategoryBrand { get; set; }
    }

}
