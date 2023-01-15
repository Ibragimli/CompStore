using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.ViewModels
{
    public class DetailViewModel
    {
        public Product Products { get; set; }
        public Comment Comments { get; set; }
        public List<Comment> UserComments { get; set; }
        public ICollection<Product> SliderProducts { get; set; }
    }
}
