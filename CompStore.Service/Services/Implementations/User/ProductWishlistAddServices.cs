using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.User;
using CompStore.Service.Services.Interfaces.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.User
{
    public class ProductWishlistAddServices : IProductWishlistAddServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public ProductWishlistAddServices(IUnitOfWork unitOfWork, IHttpContextAccessor  httpContextAccessor, UserManager<AppUser> userManager) : base()
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public void CookieAddWish(int id)
        {
            List<CookieWishItemDto> wishItems = new List<CookieWishItemDto>();
            string existWishItem = _httpContextAccessor.HttpContext.Request.Cookies["wishItemList"];
            if (existWishItem != null)
            {
                wishItems = JsonConvert.DeserializeObject<List<CookieWishItemDto>>(existWishItem);
            }
            CookieWishItemDto item = wishItems.Find(x => x.ProductId == id);
            if (item == null)
            {
                item = new CookieWishItemDto
                {
                    ProductId = id,
                };
                wishItems.Add(item);
            }

            var productIdStr = JsonConvert.SerializeObject(wishItems);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("wishItemList", productIdStr);
            var wishData = _getCookieWishItems(wishItems);
        }
        public async Task<AppUser> IsAuthenticated()
        {
            AppUser user = null;
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            }
            return user;
        }
        public async Task IsProduct(int id)
        {
            if (!await _unitOfWork.ProductRepository.IsExistAsync(x => x.Id == id))
            {
                throw new ItemNotFoundException("Mehsul Tapilmadi");
            }
        }
        public async Task<WishProductCreateDto> UserAddWish(int id, AppUser user)
        {
            WishItem wishItem = await _unitOfWork.WishItemRepository.GetAsync(x => x.AppUserId == user.Id && x.ProductId == id);

            if (wishItem == null)
            {
                wishItem = new WishItem
                {
                    AppUserId = user.Id,
                    ProductId = id,
                };
                await _unitOfWork.WishItemRepository.InsertAsync(wishItem);
            }

            await _unitOfWork.CommitAsync();

            var wishData = _getUserWishItems(await _unitOfWork.WishItemRepository.GetAllAsync(x => x.AppUserId == user.Id));
            return wishData;
        }
        async Task<WishProductCreateDto> _getCookieWishItems(List<CookieWishItemDto> cookieWishItems)
        {
            WishProductCreateDto wishItems = new WishProductCreateDto()
            {
                WishItems = new List<WishItemsDto>(),
            };
         
            foreach (var item in cookieWishItems)
            {

                var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == item.ProductId);
                WishItemsDto wishItem = new WishItemsDto
                {
                    Name = product.Name,
                    Price = (decimal)(product.DiscountPercent > 0 ? (product.Price * (1 - product.DiscountPercent / 100)) : product.Price),
                    ProductId = product.Id,
                    StockStatus = product.IsFeatured,
                    DiscountPercent = (decimal)product.DiscountPercent,
                };
            }
            return wishItems;
        }



        WishProductCreateDto _getUserWishItems(IEnumerable<WishItem> wishItems)
        {
            WishProductCreateDto wish = new WishProductCreateDto
            {
                WishItems = new List<WishItemsDto>(),
            };
            foreach (var item in wishItems)
            {
                WishItemsDto wishItem = new WishItemsDto
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

     
        WishProductCreateDto IProductWishlistAddServices._getCookieWishItems(List<CookieWishItemDto> cookieWishItems)
        {
            throw new NotImplementedException();
        }

        WishProductCreateDto IProductWishlistAddServices._getUserWishItems(IEnumerable<WishItem> wishItems)
        {
            throw new NotImplementedException();
        }


        //Start

    }
}
