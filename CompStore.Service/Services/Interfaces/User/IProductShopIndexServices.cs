using CompStore.Core.Entites;
using CompStore.Service.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.User
{
    public interface IProductShopIndexServices
    {
        public Task<ShopIndexDto> ShopCreateViewModel(int pageIndex = 1, int pageSize = 12);
        public Task<Product> ProductCreate();
    }
}
