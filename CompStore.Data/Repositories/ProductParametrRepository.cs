using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Data.Repositories
{
    public class ProductParametrRepository : Repository<ProductParametr>, IProductParametrRepository
    {
        public ProductParametrRepository(DataContext context) : base(context)
        {
        }
    }
}
