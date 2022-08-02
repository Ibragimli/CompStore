using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IProductDeleteServices
    {

        void PosterImageDelete(Product product);
        void ImagesDelete(Product product);
        Task<bool> ProductParametrDelete(Product product);
        Task<bool> DaxiliYaddasDelete(Product product);
        void ProductDelete(Product product);
    }
}
