using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Areas.Manage.ViewModels
{
    public class CategoryBrandIdEditViewModel
    {
        public int Id { get; set; }
        public ICollection<Brand> Brands { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
