using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CompStore.Mvc.Areas.Manage.Controllers.ProductController;

namespace CompStore.Mvc.Areas.Manage.ViewModels
{
    public class EditProductViewModel
    {
        public Product Product { get; set; }
        public EditCreateViewModel viewModel { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }


    }
    public class EditPostViewModel
    {
        public Product Product { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }

    }
}

