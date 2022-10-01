using CompStore.Data;
using CompStore.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeIndexViewModel homeIndex = new HomeIndexViewModel
            {
                FeaturedProducts = _context.Products.Include(x => x.ProductImages).Where(x => x.IsFeatured == true && x.IsDelete == false).ToList(),
                Products = _context.Products.Include(x => x.ProductImages).Include(x => x.CategoryBrandId).ThenInclude(x=>x.Brand).Include(x => x.CategoryBrandId).ThenInclude(x => x.Category).Where(x => x.IsDelete == false).ToList(),
                Brands = _context.Brands.Where(x => x.IsDelete == false).ToList(),
                CategoryBrandIds = _context.CategoryBrandIds.Include(x => x.Brand).Include(x => x.Category).Where(x => x.IsDelete == false).ToList(),
                MainSliders = _context.MainSliders.Where(x => x.IsDelete == false).ToList(),
                MainSpecialBoxes = _context.MainSpecialBox.Where(x => x.IsDelete == false).ToList(),
            };
            return View(homeIndex);
        }
    }
}
