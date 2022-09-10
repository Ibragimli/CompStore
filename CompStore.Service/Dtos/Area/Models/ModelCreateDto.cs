using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.Models
{
    public class ModelCreateDto
    {

        public Model Model { get; set; }
        public ICollection<Brand> Brands { get; set; }
        public ICollection<CategoryBrandId> CategoryBrandIds { get; set; }
    }
}
