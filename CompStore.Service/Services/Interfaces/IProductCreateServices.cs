using CompStore.Core.Entites;
using CompStore.Service.Dtos.Area.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IProductCreateServices
    {
        Task<DaxiliYaddaş> CreateDY(CreatePostDto create);
        Task<ProductParametr> CreatePP(CreatePostDto create, DaxiliYaddaş daxiliYaddaş);
        void ProductUpdate(Product product, CreatePostDto create, ProductParametr parametr);
        void PosterCheck(Product Image);
        void ImagesCheck(Product Images);
        void CreateImage(Product Image,bool value);
        void SaveChange(Product product);

    }
}
