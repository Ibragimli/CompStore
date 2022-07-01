using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class ProductImage:BaseEntity
    {
        public string Image { get; set; }
        public bool PosterStatus { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
