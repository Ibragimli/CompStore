using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompStore.Data.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private readonly DataContext _context;

        public BrandRepository(DataContext context) : base(context)
        {
            _context = context;
        }
      
    }

}
