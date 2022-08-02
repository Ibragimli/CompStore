using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CompStore.Mvc.Areas.Manage.Controllers.ProductController;

namespace CompStore.Mvc.Areas.Manage.ViewModels
{
    public class CreateViewModel
    {
        public Product Product { get; set; }
        public List<CategoryBrandId> CategoryBrandIds { get; set; }
        public CategoryBrandId CategoryBrand { get; set; }
        public ProductParametr ProductParametr { get; set; }
        public EditCreateViewModel viewModel { get; set; }
    }
    public class CreatePostViewModel
    {
        public Product Product { get; set; }
        public ProductParametr ProductParametr { get; set; }
        public CategoryBrandId CategoryBrand { get; set; }
    }
    public class EditCreateViewModel
    {
        public Product Product { get; set; }
        public List<SSDHecm> SSDHecms { get; set; }
        public List<Category> Categorys { get; set; }
        public List<CategoryBrandId> CategoryBrandIds { get; set; }
        public List<ProductParametr> ProductParametrs { get; set; }
        public List<Color> Colors { get; set; }
        public List<Model> Models { get; set; }
        public List<Brand> Brands { get; set; }
        public List<ProcessorCache> ProcessorCaches { get; set; }
        public List<ProcessorGhz> ProcessorGhzs { get; set; }
        public List<ProcessorModel> ProcessorModels { get; set; }
        public List<HDDHecm> HDDHecms { get; set; }
        public List<DaxiliYaddaş> DaxiliYaddaşs { get; set; }
        public List<OperationSystem> OperationSystems { get; set; }
        public List<RamDDR> RamDDRs { get; set; }
        public List<RamGB> RamGBs { get; set; }
        public List<RamMhz> RamMhzs { get; set; }
        public List<ScreenDiagonal> ScreenDiagonals { get; set; }
        public List<ScreenFrequency> ScreenFrequencies { get; set; }
        public List<Teyinat> Teyinats { get; set; }
        public List<SSDType> SSDTypes { get; set; }
        public List<Videokart> Videokarts { get; set; }
        public List<VideokartRam> VideokartRams { get; set; }
        public List<GörüntüImkanı> GörüntüImkanıs { get; set; }
    }

}
