using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Repositories
{
    public class ProductCreateRepository : Repository<Product>, IProductCreateRepository
    {
        public ProductCreateRepository(DataContext context) : base(context)
        {
        }
    }
}
