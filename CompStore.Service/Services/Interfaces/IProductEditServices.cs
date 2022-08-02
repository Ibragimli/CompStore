using CompStore.Core.Entites;
using CompStore.Service.Dtos.Area.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IProductEditServices
    {
        Task<bool>  IsExistProduct(int id);
        void AddPosterImage(Product product, Product productExist);
        void AddImages(Product product, Product productExist);
        void DeleteImages(Product product, Product productExist);
        void CheckDaxiliYaddas(Product product, Product productExist);
        Task<Product> ExistProduct(int id);

    }
}
