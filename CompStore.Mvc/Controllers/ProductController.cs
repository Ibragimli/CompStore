using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.ViewModels;
using CompStore.Service.Helper;
using Microsoft.AspNetCore.Http;
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
            var prd = _context.Products
                .Include(x => x.ProductImages)
                .Include(x => x.Model)
                .Include(x => x.ProductParametr)
                .Include(x => x.ProductParametr).ThenInclude(x => x.Color)
                .Include(x => x.ProductParametr).ThenInclude(x => x.DaxiliYaddaş)
                .Include(x => x.ProductParametr.DaxiliYaddaş).ThenInclude(x => x.SSDType)
                .Include(x => x.ProductParametr.DaxiliYaddaş).ThenInclude(x => x.SSDHecm)
                .Include(x => x.ProductParametr.DaxiliYaddaş).ThenInclude(x => x.HDDHecm)
                .Include(x => x.ProductParametr).ThenInclude(x => x.Videokart)
                .Include(x => x.ProductParametr).ThenInclude(x => x.ScreenDiagonal)
                .Include(x => x.ProductParametr).ThenInclude(x => x.ScreenFrequency)
                .Include(x => x.ProductParametr).ThenInclude(x => x.OperationSystem)
                .Include(x => x.ProductParametr).ThenInclude(x => x.ProcessorCache)
                .Include(x => x.ProductParametr).ThenInclude(x => x.ProcessorModel)
                .Include(x => x.ProductParametr).ThenInclude(x => x.ProcessorGhz)
                .Include(x => x.ProductParametr).ThenInclude(x => x.ProcessorCache)
                .Include(x => x.ProductParametr).ThenInclude(x => x.RamDDR)
                .Include(x => x.ProductParametr).ThenInclude(x => x.RamGB)
                .Include(x => x.ProductParametr).ThenInclude(x => x.RamMhz)
                .Include(x => x.ProductParametr).ThenInclude(x => x.Videokart)
                .Include(x => x.ProductParametr).ThenInclude(x => x.VideokartRam)
                .Include(x => x.ProductParametr).ThenInclude(x => x.Teyinat)
                .Include(x => x.ProductParametr).ThenInclude(x => x.GörüntüImkanı)
                .Include(x => x.CategoryBrandId).ThenInclude(x => x.Category)
                .Include(x => x.CategoryBrandId).ThenInclude(x => x.Brand)
                .Where(x => x.IsDelete == false).FirstOrDefault(x => x.Id == id);
            if (prd == null) return RedirectToAction("notfound", "error");

            DetailViewModel detailVM = new DetailViewModel
            {
                Products = prd,
                SliderProducts = _context.Products.Include(x => x.ProductImages)
                .Include(x => x.CategoryBrandId.Brand)
                .Include(x => x.CategoryBrandId.Category)
                .Where(x => x.CategoryBrandId.CategoryId == prd.CategoryBrandId.CategoryId && x.CategoryBrandId.BrandId == prd.CategoryBrandId.BrandId).ToList(),
            };
            return View(detailVM);

        }

        public IActionResult Mehsullar(int page = 1)
        {
            var products = _context.Products
                .Include(x => x.CategoryBrandId.Category)
                .Include(x => x.CategoryBrandId.Brand)
                .Include(x => x.ProductImages)
                .Where(x => x.IsDelete == false).AsQueryable();

            ShopViewModel shopVM = new ShopViewModel
            {
                Products = _context.Products.Include(x => x.ProductImages).Include(x => x.CategoryBrandId.Category).Include(x => x.CategoryBrandId.Brand).Where(x => x.IsDelete == false).ToList(),
                Brands = _context.Brands.Where(x => x.IsDelete == false).ToList(),
                Categories = _context.Categories.Where(x => x.IsDelete == false).ToList(),
                CategoryBrandIds = _context.CategoryBrandIds.Where(x => x.IsDelete == false).ToList(),
                PagenatedProducts = PagenetedList<Product>.Create(products, page, 16),
            };
            return View(shopVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Mehsullar(int page = 1, int? brandId = null, int? categoryId = null)
        {
            var products = _context.Products
                .Include(x => x.CategoryBrandId.Category)
                .Include(x => x.CategoryBrandId.Brand)
                .Include(x => x.ProductImages)
                .Where(x => x.IsDelete == false).AsQueryable();

            if (categoryId != null && categoryId != 0)
            {
                products = products.Where(x => x.CategoryBrandId.CategoryId == categoryId);
            }

            if (brandId != null && brandId != 0)
            {
                products = products.Where(x => x.CategoryBrandId.BrandId == brandId);
            }
            ShopViewModel shopVM = new ShopViewModel
            {
                Products = _context.Products.Include(x => x.ProductImages).Include(x => x.CategoryBrandId.Category).Include(x => x.CategoryBrandId.Brand).Where(x => x.IsDelete == false).ToList(),
                Brands = _context.Brands.Where(x => x.IsDelete == false).ToList(),
                Categories = _context.Categories.Where(x => x.IsDelete == false).ToList(),
                CategoryBrandIds = _context.CategoryBrandIds.Where(x => x.IsDelete == false).ToList(),
                PagenatedProducts = PagenetedList<Product>.Create(products, page, 16),
            };
            return View(shopVM);
        }
    }
}
