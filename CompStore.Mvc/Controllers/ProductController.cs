using CompStore.Data;
using CompStore.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Detail(int id)
        {
            var prd = _context.Products.Include(x => x.ProductImages).Include(x => x.Category).ThenInclude(x => x.CategoryBrandIds).Where(x => x.IsDelete == false).FirstOrDefault(x => x.Id == id);
            if (prd == null)
            {
                return RedirectToAction("notfound", "error");

            }
            DetailViewModel detailVM = new DetailViewModel
            {
                Products = prd,
            };
            return View(detailVM);

        }
    }
}
