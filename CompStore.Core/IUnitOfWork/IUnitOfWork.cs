using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Core.Repositories
{
    public interface IUnitOfWork
    {
        IAdminAccountRepository AdminAccountRepository { get; }
        IDaxiliYaddasRepository DaxiliYaddasRepository { get; }
        IProductParametrRepository ProductParametrRepository { get; }
        ICategoryBrandIdRepository CategoryBrandIdRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductImagesRepositroy ProductImagesRepositroy { get; }

        IBrandRepository BrandRepository { get; }

        Task<int> CommitAsync();
    }
}
