using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class CategoryBrandId:BaseEntity
    {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }

    }
}
