using CompStore.Core.Repositories;
using CompStore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IAdminAccountRepository _adminAccountRepository;
        private IProductParametrRepository _productParametrRepository;
        private IDaxiliYaddasRepository _daxiliYaddasRepository;
        private ICategoryBrandIdRepository _categoryBrandIdRepository;
        private IProductImagesRepositroy _productImagesRepositroy;
        private IProductRepository _productRepository;
        private IModelRepository _modelRepository;

        private IBrandRepository _brandRepository;

        private ITeyinatRepository _teyinatRepository;
        private IColorRepository _colorRepository;
        private ICategoryRepository _categoryRepository;


        private IGörüntüImkanıRepository _görüntüImkanıRepository;
        private IOperationSystemsRepository _operationSystemsRepository;
        private IVideokartRamsRepository _videokartRamsRepository;
        private IVideokartRepository _videokartRepository;
        private IImageSettingRepository _imageSettingRepository;
        private IHDDHecmsRepository _hDDHecmsRepository;

        private IRamDDRRepository _ramDDRRepository;
        private IRamGBRepository _ramGBRepository;
        private IRamMhzRepository _ramMhzRepository;
        private IScreenDiagonalRepository _screenDiagonalRepository;
        private IScreenFrequencieRepository _screenFrequencieRepository;
        private ISSDHecmRepository _sSDHecmRepository;
        private ISSDTypeRepository _sSDTypeRepository;
        private IProcessorCacheRepository _processorCacheRepository;
        private IProcessorGhzRepository _processorGhzRepository;
        private IProcessorModelRepository _processorModelRepository;


        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IRamDDRRepository RamDDRRepository => _ramDDRRepository = _ramDDRRepository ?? new RamDDRRepository(_context);
        public IRamGBRepository RamGBRepository => _ramGBRepository = _ramGBRepository ?? new RamGBRepository(_context);
        public IRamMhzRepository RamMhzRepository => _ramMhzRepository = _ramMhzRepository ?? new RamMhzRepository(_context);
        public IScreenDiagonalRepository ScreenDiagonalRepository => _screenDiagonalRepository = _screenDiagonalRepository ?? new ScreenDiagonalRepository(_context);
        public IScreenFrequencieRepository ScreenFrequencieRepository => _screenFrequencieRepository = _screenFrequencieRepository ?? new ScreenFrequencieRepository(_context);
        public ISSDHecmRepository SSDHecmRepository => _sSDHecmRepository = _sSDHecmRepository ?? new SSDHecmRepository(_context);
        public ISSDTypeRepository SSDTypeRepository => _sSDTypeRepository = _sSDTypeRepository ?? new SSDTypeRepository(_context);
        public IProcessorCacheRepository ProcessorCacheRepository => _processorCacheRepository = _processorCacheRepository ?? new ProcessorCacheRepository(_context);
        public IProcessorGhzRepository ProcessorGhzRepository => _processorGhzRepository = _processorGhzRepository ?? new ProcessorGhzRepository(_context);
        public IProcessorModelRepository ProcessorModelRepository => _processorModelRepository = _processorModelRepository ?? new ProcessorModelRepository(_context);

        public IBrandRepository BrandRepository => _brandRepository = _brandRepository ?? new BrandRepository(_context);

        public IAdminAccountRepository AdminAccountRepository => _adminAccountRepository = _adminAccountRepository ?? new AdminAccountRepository(_context);

        public IDaxiliYaddasRepository DaxiliYaddasRepository => _daxiliYaddasRepository = _daxiliYaddasRepository ?? new DaxiliYaddasRepository(_context);

        public IProductParametrRepository ProductParametrRepository => _productParametrRepository = _productParametrRepository ?? new ProductParametrRepository(_context);
        public ICategoryBrandIdRepository CategoryBrandIdRepository => _categoryBrandIdRepository = _categoryBrandIdRepository ?? new CategoryBrandIdRepository(_context);
        public IProductImagesRepositroy ProductImagesRepositroy => _productImagesRepositroy = _productImagesRepositroy ?? new ProductImagesRepository(_context);

        public IProductRepository ProductRepository => _productRepository = _productRepository ?? new ProductRepository(_context);

        public IModelRepository modelRepository => _modelRepository = _modelRepository ?? new ModelRepository(_context);

        public IColorRepository ColorRepository => _colorRepository = _colorRepository ?? new ColorRepository(_context);

        public ITeyinatRepository TeyinatRepository => _teyinatRepository = _teyinatRepository ?? new TeyinatRepository(_context);

        public ICategoryRepository CategoryRepository => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public IGörüntüImkanıRepository GörüntüImkanıRepository => _görüntüImkanıRepository = _görüntüImkanıRepository ?? new GörüntüImkanıRepository(_context);

        public IOperationSystemsRepository OperationSystemsRepository => _operationSystemsRepository = _operationSystemsRepository ?? new OperationSystemsRepository(_context);

        public IVideokartRamsRepository VideokartRamsRepository => _videokartRamsRepository = _videokartRamsRepository ?? new VideokartRamsRepository(_context);

        public IVideokartRepository VideokartRepository => _videokartRepository = _videokartRepository ?? new VideokartRepository(_context);

        public IImageSettingRepository ImageSettingRepository => _imageSettingRepository = _imageSettingRepository ?? new ImageSettingRepository(_context);

        public IHDDHecmsRepository HDDHecmsRepository => _hDDHecmsRepository = _hDDHecmsRepository ?? new HDDHecmsRepository(_context);



        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
