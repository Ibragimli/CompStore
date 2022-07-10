using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Repositories
{
    public class AdminAccountRepository : Repository<AppUser>, IAdminAccountRepository
    {
        public AdminAccountRepository(DataContext context) : base(context)
        {
        }
    }
}
