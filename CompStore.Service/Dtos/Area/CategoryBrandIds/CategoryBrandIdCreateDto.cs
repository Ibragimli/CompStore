using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.CategoryBrandIds
{
   public  class CategoryBrandIdCreateDto
    {
        public CategoryBrandId CategoryBrandId { get; set; }
        public ICollection<Brand> Brands { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
