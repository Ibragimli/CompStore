using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.ViewModels;
using CompStore.Service.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompStore.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;


        public ProductController(DataContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        //public IActionResult Mehsullar(int page = 1)
        //{
        //    var products = _context.Products
        //        .Include(x => x.CategoryBrandId.Category)
        //        .Include(x => x.CategoryBrandId.Brand)
        //        .Include(x => x.ProductImages)
        //        .Where(x => x.IsDelete == false).AsQueryable();

        //    ShopViewModel shopVM = new ShopViewModel
        //    {
        //        Products = _context.Products.Include(x => x.ProductImages).Include(x => x.CategoryBrandId.Category).Include(x => x.CategoryBrandId.Brand).Where(x => x.IsDelete == false).ToList(),
        //        Brands = _context.Brands.Where(x => x.IsDelete == false).ToList(),
        //        Categories = _context.Categories.Where(x => x.IsDelete == false).ToList(),
        //        CategoryBrandIds = _context.CategoryBrandIds.Where(x => x.IsDelete == false).ToList(),
        //        PagenatedProducts = PagenetedList<Product>.Create(products, page, 16),
        //    };
        //    return View(shopVM);
        //}

        public IActionResult Mehsullar(int page = 1)
        {
            var products = _context.Products
                .Include(x => x.CategoryBrandId.Category)
                .Include(x => x.CategoryBrandId.Brand)
                .Include(x => x.ProductImages)
                .Where(x => x.IsDelete == false).AsQueryable();

            List<CategoryFilterViewModel> items = new List<CategoryFilterViewModel>();


            //if (categoryItemsStr != null)
            //{
            //    items = JsonConvert.DeserializeObject<List<CategoryFilterViewModel>>(categoryItemsStr);
            //}



            //foreach (var item in categoryItemsStr)
            //{
            //    products.Where(x => x.CategoryBrandId.CategoryId == item);
            //}

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
        public IActionResult FilterMehsul(string arry = null)
        {
            var products = _context.Products
                .Include(x => x.CategoryBrandId.Category)
                .Include(x => x.CategoryBrandId.Brand)
                .Include(x => x.ProductImages)
                .Where(x => x.IsDelete == false).AsQueryable();

            //if (CategoryIds != null)
            //{
            //    foreach (var id in CategoryIds.CategoryIds)
            //    {
            //        products.Where(x => x.CategoryBrandId.CategoryId == id);
            //    }
            //}

            ShopViewModel shopVM = new ShopViewModel
            {
                Products = _context.Products.Include(x => x.ProductImages).Include(x => x.CategoryBrandId.Category).Include(x => x.CategoryBrandId.Brand).Where(x => x.IsDelete == false).ToList(),
                Brands = _context.Brands.Where(x => x.IsDelete == false).ToList(),
                Categories = _context.Categories.Where(x => x.IsDelete == false).ToList(),
                CategoryBrandIds = _context.CategoryBrandIds.Where(x => x.IsDelete == false).ToList(),
                PagenatedProducts = PagenetedList<Product>.Create(products, 1, 16),
            };
            return View(shopVM);
        }

        [HttpPost]
        public JsonResult Delete(string json)
        {
            var serializer = new JsonSerializer();
            dynamic jsondata = JsonConvert.DeserializeObject(json);

            //Get your variables here from AJAX call
            var checboxValues = jsondata["myCheckboxes"];
            var mySelectedValue = jsondata["mySelectedValue"];
            //Do your stuff
            return Json(mySelectedValue);
        }




        public async Task<IActionResult> AddWishList(int id)
        {
            if (!_context.Products.Any(x => x.Id == id))
            {
                return RedirectToAction("error", "error");
            }
            WishViewModel wishData = null;
            AppUser user = null;
            if (User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(User.Identity.Name);
            }

            if (user != null && user.IsAdmin == false)
            {

                WishItem wishItem = _context.WishItems.FirstOrDefault(x => x.AppUserId == user.Id && x.ProductId == id);

                if (wishItem == null)
                {
                    wishItem = new WishItem
                    {
                        AppUserId = user.Id,
                        ProductId = id,
                    };
                    _context.WishItems.Add(wishItem);
                }

                _context.SaveChanges();

                wishData = _getWishItems(_context.WishItems.Include(x => x.Product).Where(x => x.AppUserId == user.Id).ToList());

            }
            else
            {
                List<CookieWishItemViewModel> wishItems = new List<CookieWishItemViewModel>();
                string existWishItem = HttpContext.Request.Cookies["wishItemList"];
                if (existWishItem != null)
                {
                    wishItems = JsonConvert.DeserializeObject<List<CookieWishItemViewModel>>(existWishItem);
                }
                CookieWishItemViewModel item = wishItems.FirstOrDefault(x => x.ProductId == id);
                if (item == null)
                {
                    item = new CookieWishItemViewModel
                    {
                        ProductId = id,
                    };
                    wishItems.Add(item);
                }

                var productIdStr = JsonConvert.SerializeObject(wishItems);
                HttpContext.Response.Cookies.Append("wishItemList", productIdStr);
                wishData = _getWishItems(wishItems);
            }

          
            TempData["Success"] = "Product add wishlist";

            return Ok(wishData);
        }


        public IActionResult DeleteWish(int id)
        {
            AppUser user = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && x.IsAdmin == false);
            if (!_context.Products.Any(x => x.Id == id))
            {
                return RedirectToAction("error", "error");
            }
            List<WishItemViewModel> wishItems = new List<WishItemViewModel>();

            if (user != null && !user.IsAdmin)
            {
                WishItem wishItem = _context.WishItems.FirstOrDefault(x => x.ProductId == id);
                if (wishItem == null)
                {
                    return RedirectToAction("error", "error");
                }

                _context.WishItems.Remove(wishItem);
                _context.SaveChanges();
            }
            else
            {
                string wish = HttpContext.Request.Cookies["wishItemList"];
                wishItems = JsonConvert.DeserializeObject<List<WishItemViewModel>>(wish);
                WishItemViewModel productWish = wishItems.FirstOrDefault(x => x.ProductId == id);
                if (productWish == null)
                {
                    return RedirectToAction("error", "error");
                }

                wishItems.Remove(productWish);

            }


            HttpContext.Response.Cookies.Append("wishItemList", JsonConvert.SerializeObject(wishItems));
            return Ok(wishItems);

        }

        private WishViewModel _getWishItems(List<CookieWishItemViewModel> cookieWishItems)
        {

            WishViewModel wishItems = new WishViewModel()
            {
                WishItems = new List<WishItemViewModel>(),
            };
            foreach (var item in cookieWishItems)
            {
                Product product = _context.Products.FirstOrDefault(x => x.Id == item.ProductId);
                WishItemViewModel wishItem = new WishItemViewModel
                {
                    Name = product.Name,
                    Price = (decimal)(product.DiscountPercent > 0 ? (product.Price * (1 - product.DiscountPercent / 100)) : product.Price),
                    SalePrice = (decimal)product.Price,
                    ProductId = product.Id,
                    StockStatus = product.IsFeatured,
                    DiscountPercent = (decimal)product.DiscountPercent,
                };
            }
            return wishItems;

        }
        private WishViewModel _getWishItems(List<WishItem> wishItems)
        {
            WishViewModel wish = new WishViewModel
            {
                WishItems = new List<WishItemViewModel>(),
            };
            foreach (var item in wishItems)
            {
                WishItemViewModel wishItem = new WishItemViewModel
                {
                    Name = item.Product.Name,
                    Price = item.Product.DiscountPercent > 0 ? (decimal)(item.Product.Price * (1 - item.Product.DiscountPercent / 100)) : (decimal)item.Product.Price,
                    ProductId = item.Product.Id,
                    //StockStatus = item.Product.StockStatus,
                };
                wish.WishItems.Add(wishItem);
            }
            return wish;
        }
    }
}
