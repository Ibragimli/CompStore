using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private readonly DataContext _context;
        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Product> asQueryableProduct()
        {
            var products = _context.Products
               .Include(x => x.ProductImages)
               .Include(x => x.Model)
               .Include(x => x.CategoryBrandId)
               .ThenInclude(x => x.Category)
               .AsQueryable();
            return products;
        }

       
    }
}
