using CompStore.Core.Entites;
using CompStore.Service.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.User
{
    public interface IProductWishlistDeleteServices
    {
        Task IsProduct(int id);
        Task<WishItem> UserDeleteWish(int id, AppUser user);
        List<WishItemDto> CookieDeleteWish(int id, List<WishItemDto> wishItems);
        Task<AppUser> IsAuthenticated();
    }
}
