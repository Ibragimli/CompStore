using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CompStore.Core.Entites
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public string BrandImage { get; set; }
        [NotMapped]
        public IFormFile BrandImageFile { get; set; }
        public ICollection<CategoryBrandId> CategoryBrandIds { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}
