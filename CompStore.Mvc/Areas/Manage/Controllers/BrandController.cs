using CompStore.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Areas.Manage.Controllers
{
    [Area("manage")]
    public class BrandController
    {
        private readonly DataContext _context;

        public BrandController(DataContext context)
        {
            _context = context;
        }
        //public IActionResult Index(int page = 1)
        //{
        //    return view

        //}

    }
}
