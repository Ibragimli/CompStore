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
    public class ProductWishlistDeleteServices : IProductWishlistDeleteServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public ProductWishlistDeleteServices(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager) : base()
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public List<WishItemDto> CookieDeleteWish(int id, List<WishItemDto> wishItems)
        {
            string wish = _httpContextAccessor.HttpContext.Request.Cookies["wishItemList"];
            wishItems = JsonConvert.DeserializeObject<List<WishItemDto>>(wish);
            WishItemDto productWish = wishItems.Find(x => x.ProductId == id);
            if (productWish == null) throw new ItemNotFoundException("Mehsul Tapilmadi");

            wishItems.Remove(productWish);

            //    string wish = HttpContext.Request.Cookies["wishItemList"];
            //    wishItems = JsonConvert.DeserializeObject<List<WishItemViewModel>>(wish);
            //    WishItemViewModel productWish = wishItems.FirstOrDefault(x => x.ProductId == id);
            //    if (productWish == null)
            //    {
            //        return RedirectToAction("error", "error");
            //    }
            //    wishItems.Remove(productWish);

            return wishItems;
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

        public async Task<WishItem> UserDeleteWish(int id, AppUser user)
        {
            WishItem wishItem = await _unitOfWork.WishItemRepository.GetAsync(x => x.ProductId == id);
            if (wishItem == null)
            {
                throw new ItemNotFoundException("Mehsul Tapilmadi");
            }

            _unitOfWork.WishItemRepository.Remove(wishItem);
            await _unitOfWork.CommitAsync();
            return wishItem;
        }
    }
}
