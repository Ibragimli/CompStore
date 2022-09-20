using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IProductDetailServices
    {
        Task<Product> isProduct(int id);

    }
}
