using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class Model : BaseEntity
    {
        public string Name { get; set; }
        public int CategoryBrandIdId { get; set; }
        public int BrandId { get; set; }
        public CategoryBrandId CategoryBrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
