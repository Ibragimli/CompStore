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
        IModelRepository modelRepository { get; }

        IColorRepository ColorRepository { get; }
        ITeyinatRepository TeyinatRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        IGörüntüImkanıRepository GörüntüImkanıRepository { get; }
        IOperationSystemsRepository OperationSystemsRepository { get; }
        IVideokartRamsRepository VideokartRamsRepository { get; }
        IVideokartRepository VideokartRepository { get; }
        IImageSettingRepository ImageSettingRepository { get; }
        IHDDHecmsRepository HDDHecmsRepository { get; }


        IRamDDRRepository RamDDRRepository { get; }
        IRamGBRepository RamGBRepository { get; }
        IRamMhzRepository RamMhzRepository { get; }
        IScreenDiagonalRepository ScreenDiagonalRepository { get; }
        IScreenFrequencieRepository ScreenFrequencieRepository { get; }
        ISSDHecmRepository SSDHecmRepository { get; }
        ISSDTypeRepository SSDTypeRepository { get; }
        IProcessorCacheRepository ProcessorCacheRepository { get; }
        IProcessorGhzRepository ProcessorGhzRepository { get; }
        IProcessorModelRepository ProcessorModelRepository { get; }
        ISettingRepository SettingRepository { get; }

        Task<int> CommitAsync();
    }
}
