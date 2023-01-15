using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.ViewModels;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.User;
using CompStore.Service.Helper;
using CompStore.Service.Services.Interfaces.User;
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
        private readonly IProductWishlistAddServices _productWishlistAddServices;
        private readonly IProductWishlistDeleteServices _productWishlistDeleteServices;
        private readonly ICommentAddServices _commentAddServices;

        public ProductController(DataContext context, UserManager<AppUser> userManager, IProductWishlistAddServices productWishlistAddServices, IProductWishlistDeleteServices productWishlistDeleteServices, ICommentAddServices commentAddServices)
        {
            _context = context;
            _userManager = userManager;
            _productWishlistAddServices = productWishlistAddServices;
            _productWishlistDeleteServices = productWishlistDeleteServices;
            _commentAddServices = commentAddServices;
        }
        public IActionResult Detail(int id)
        {
            var prd = _context.Products
                .Include(x => x.ProductImages)
                .Include(x => x.Model)
                .Include(x => x.Comments)
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

            ViewBag.productId = id;
            ViewBag.RatePoint = 0;
            int ratePoint = 0;
            int countRate = 0;
            Product product = _getProductContext(id); ;
            if (product == null)
            {
                return RedirectToAction("error", "error");
            }

            if (product.Comments.Count() > 0)
            {
                foreach (var comment in product.Comments.Where(x => x.CommentStatus == true))
                {
                    countRate++;
                    ratePoint += comment.Rate;
                }
                if (countRate != 0)
                {
                    ratePoint = ratePoint / countRate;
                    ViewBag.RatePoint = ratePoint;
                }
            }
        
            ProductDetailDto detailDto = new ProductDetailDto
            {
                Comments = new Comment(),
                UserComments = _context.Comments.Where(x => x.ProductId == id).ToList(),
                Products = prd,
                ProductCommentPostDto = new ProductCommentPostDto
                {
                    Comment = new Comment(),
                    ProductId = id,
                },
                SliderProducts = _context.Products.Include(x => x.ProductImages)
                .Include(x => x.CategoryBrandId.Brand)
                .Include(x => x.CategoryBrandId.Category)
                .Where(x => x.CategoryBrandId.CategoryId == prd.CategoryBrandId.CategoryId && x.CategoryBrandId.BrandId == prd.CategoryBrandId.BrandId).ToList(),
            };
            return View(detailDto);
        }

        [HttpPost]
        public async Task<IActionResult> Comment(ProductCommentPostDto productCommentPostDto)
        {
            var commentNew = new Comment();
            try
            {
                commentNew = await _commentAddServices.CreateComment(productCommentPostDto.Comment);
            }
            catch (SizeFormatException ex)
            {
                //ModelState.AddModelError("", ex.Message);
                TempData["Error"] = ex.Message;
                return RedirectToAction("detail", new { Id = productCommentPostDto.Comment.ProductId });
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", ex.Message);
                TempData["Error"] = ex.Message;
                return RedirectToAction("detail", new { Id = productCommentPostDto.Comment.ProductId });
            }
            TempData["Success"] = "Comment added successfully";
            return RedirectToAction("detail", new { Id = productCommentPostDto.Comment.ProductId });
        }

        private Product _getProductContext(int id)
        {
            Product product = _context.Products.Include(x => x.ProductImages)
                .Include(x => x.CategoryBrandId).ThenInclude(x => x.Brand)
                .Include(x => x.CategoryBrandId).ThenInclude(x => x.Category)
                .Include(x => x.Comments)
                .FirstOrDefault(x => x.Id == id);
            return product;
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
            WishViewModel wishData = null;
            try
            {
                await _productWishlistAddServices.IsProduct(id);
                var user = await _productWishlistAddServices.IsAuthenticated();
                if (user != null && user.IsAdmin == false) await _productWishlistAddServices.UserAddWish(id, user);
                else _productWishlistAddServices.CookieAddWish(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = "Product add wishlist";
            return Ok(wishData);
        }

        public async Task<IActionResult> DeleteWish(int id)
        {
            List<WishItemDto> wishItems = null;
            try
            {
                await _productWishlistDeleteServices.IsProduct(id);
                var user = await _productWishlistAddServices.IsAuthenticated();
                if (user != null && user.IsAdmin == false) await _productWishlistDeleteServices.UserDeleteWish(id, user);
                else wishItems = _productWishlistDeleteServices.CookieDeleteWish(id, wishItems);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            HttpContext.Response.Cookies.Append("wishItemList", JsonConvert.SerializeObject(wishItems));
            return Ok(wishItems);
        }
    }
}
