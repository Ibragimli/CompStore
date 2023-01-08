using CompStore.Core.Entites;
using CompStore.Service.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.User
{
    public interface IProductWishlistAddServices
    {
        Task IsProduct(int id);
        Task<WishProductCreateDto> UserAddWish(int id, AppUser user);
        void CookieAddWish(int id);
         WishProductCreateDto _getUserWishItems(IEnumerable<WishItem> wishItems);
         WishProductCreateDto _getCookieWishItems(List<CookieWishItemDto> cookieWishItems);
        Task<AppUser> IsAuthenticated();
    }
}
