﻿using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<Product> asQueryableProduct();
    }
}
