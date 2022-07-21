using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Core.Repositories
{
    public interface IUnitOfWork
    {
        IAdminAccountRepository AdminAccountRepository { get; }
        IProductCreateRepository ProductCreateRepository { get; }
        IDaxiliYaddasRepository DaxiliYaddasRepository { get; }
        IProductParametrRepository ProductParametrRepository { get; }
        ICategoryBrandIdRepository CategoryBrandIdRepository { get; }
        IProductImagesRepositroy ProductImagesRepositroy { get; }
        Task<int> CommitAsync();
    }
}
