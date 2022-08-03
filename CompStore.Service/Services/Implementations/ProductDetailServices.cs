using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations
{
    public class ProductDetailServices : IProductDetailServices
    {
        private readonly DataContext _context;

        public ProductDetailServices(DataContext context)
        {
            _context = context;
        }
        public async Task<Product> isProduct(int id)
        {
            var product = _context.Products.Include(x => x.CategoryBrandId).ThenInclude(x => x.Brand)
                 .Include(x => x.CategoryBrandId).ThenInclude(x => x.Category)
                 .Include(x => x.Model).Include(x => x.ProductImages)
                 .Include(x => x.ProductParametr).ThenInclude(x => x.Teyinat)
                 .Include(x => x.ProductParametr).ThenInclude(x => x.ScreenFrequency)
                 .Include(x => x.ProductParametr).ThenInclude(x => x.ScreenDiagonal)
                 .Include(x => x.ProductParametr).ThenInclude(x => x.RamMhz)
                 .Include(x => x.ProductParametr).ThenInclude(x => x.VideokartRam)
                 .Include(x => x.ProductParametr).ThenInclude(x => x.RamDDR)
                 .Include(x => x.ProductParametr).ThenInclude(x => x.RamGB)
                 .Include(x => x.ProductParametr).ThenInclude(x => x.Videokart)
                 .Include(x => x.ProductParametr).ThenInclude(x => x.ProcessorModel)
                 .Include(x => x.ProductParametr).ThenInclude(x => x.ProcessorGhz)
                 .Include(x => x.ProductParametr).ThenInclude(x => x.ProcessorCache)
                 .Include(x => x.ProductParametr).ThenInclude(x => x.OperationSystem)
                 .Include(x => x.ProductParametr).ThenInclude(x => x.GörüntüImkanı)
                 .Include(x => x.ProductParametr).ThenInclude(x => x.Color)
                 .Include(x => x.ProductParametr).ThenInclude(x => x.DaxiliYaddaş).ThenInclude(x => x.HDDHecm)
                 .Include(x => x.ProductParametr).ThenInclude(x => x.DaxiliYaddaş).ThenInclude(x => x.SSDHecm)
                 .Include(x => x.ProductParametr).ThenInclude(x => x.DaxiliYaddaş).ThenInclude(x => x.SSDType)
                 .FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                throw new ItemNotFoundException("Mehsul Tapilmadi");
            }
            return await product;
        }
    }
}
