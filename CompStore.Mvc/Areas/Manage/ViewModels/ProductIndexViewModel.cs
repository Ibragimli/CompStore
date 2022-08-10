using CompStore.Core.Entites;
using CompStore.Service.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Areas.Manage.ViewModels
{
    public class ProductIndexViewModel
    {
        public PagenetedList<Product> PagenatedProducts { get; set; }
        public string Search { get; set; }
    }
}
