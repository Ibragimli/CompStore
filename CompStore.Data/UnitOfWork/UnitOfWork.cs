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
        private IProductCreateRepository _productCreateRepository;
        private IProductParametrRepository _productParametrRepository;
        private IDaxiliYaddasRepository _daxiliYaddasRepository;
        private ICategoryBrandIdRepository _categoryBrandIdRepository;
        private IProductImagesRepositroy _productImagesRepositroy;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public IAdminAccountRepository AdminAccountRepository => _adminAccountRepository = _adminAccountRepository ?? new AdminAccountRepository(_context);

        public IProductCreateRepository ProductCreateRepository => _productCreateRepository = _productCreateRepository ?? new ProductCreateRepository(_context);

        public IDaxiliYaddasRepository DaxiliYaddasRepository => _daxiliYaddasRepository = _daxiliYaddasRepository ?? new DaxiliYaddasRepository(_context);

        public IProductParametrRepository ProductParametrRepository => _productParametrRepository = _productParametrRepository ?? new ProductParametrRepository(_context);
        public ICategoryBrandIdRepository CategoryBrandIdRepository => _categoryBrandIdRepository = _categoryBrandIdRepository ?? new CategoryBrandIdRepository(_context);
        public IProductImagesRepositroy ProductImagesRepositroy => _productImagesRepositroy = _productImagesRepositroy ?? new ProductImagesRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
