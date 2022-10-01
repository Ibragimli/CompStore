using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.ViewModels
{
    public class HomeIndexViewModel
    {
        public ICollection<Product> FeaturedProducts { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<MainSlider> MainSliders { get; set; }
        public ICollection<MainSpecialBox> MainSpecialBoxes { get; set; }
        public ICollection<Brand> Brands { get; set; }
        public ICollection<CategoryBrandId> CategoryBrandIds { get; set; }
    }
}
