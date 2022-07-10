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

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public IAdminAccountRepository AdminAccountRepository => _adminAccountRepository = _adminAccountRepository ?? new AdminAccountRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
