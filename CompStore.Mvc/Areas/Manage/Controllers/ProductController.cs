using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.Products;
using CompStore.Service.Helper;
using CompStore.Service.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IProductCreateServices _productCreate;

        public ProductController(DataContext context, IWebHostEnvironment env, IProductCreateServices productCreate)
        {
            _context = context;
            _env = env;
            _productCreate = productCreate;
        }

        // GET: Manage/Product
        public IActionResult Index(int page = 1)
        {
            var products = _context.Products
                .Include(x => x.ProductImages)
                .Include(x => x.Model)
                .Include(x => x.CategoryBrandId)
                .ThenInclude(x => x.Category)
                .AsQueryable();
            ProductIndexViewModel productIndexVM = new ProductIndexViewModel
            {
                PagenatedProducts = PagenetedList<Product>.Create(products, page, 5),
            };
            return View(productIndexVM);
        }


        // GET: Manage/Product/Create
        public IActionResult Create()
        {
            return View(_createViewModel(_context));
        }

        private void IsRequired(Product product, CategoryBrandId categoryBrand, ProductParametr parametr, Model model)
        {
            if (product.Name == null)
            {
                ModelState.AddModelError("", "Name is required");
            }
            if (product.Price == null) ModelState.AddModelError("", "Price is required");
            if (product.Description == null) ModelState.AddModelError("", "Description is required");
            if (product.DiscountPercent == null) ModelState.AddModelError("", "DiscountPercent is required");
            if (product.PosterImageFile == null) ModelState.AddModelError("PosterImageFile", "PosterImageFile is required");
            if (product.ImageFiles == null) ModelState.AddModelError("ImageFiles", "ImageFiles is required");

            if (categoryBrand.CategoryId == 0) ModelState.AddModelError("", "Category is required");
            if (categoryBrand.BrandId == 0) ModelState.AddModelError("", "Brand is required");

            if (parametr.ColorId == 0) ModelState.AddModelError("", "Color is required");
            if (parametr.GörüntüImkanıId == 0) ModelState.AddModelError("", "Görüntü Imkanı is required");
            if (parametr.OperationSystemId == 0) ModelState.AddModelError("", "Əməliyyat Sistemi  is required");
            if (parametr.ProcessorCacheId == 0) ModelState.AddModelError("", "Processor Cache is required");
            if (parametr.ProcessorModelId == 0) ModelState.AddModelError("", "Processor Model   is required");
            if (parametr.RamDDRId == 0) ModelState.AddModelError("", "Ram DDR    is required");
            if (parametr.RamGBId == 0) ModelState.AddModelError("", "Ram GB    is required");
            if (parametr.RamMhzId == 0) ModelState.AddModelError("", "Ram Mhz    is required");
            if (parametr.ScreenDiagonalId == 0) ModelState.AddModelError("", "Screen Diagonal    is required");
            if (parametr.ScreenFrequencyId == 0) ModelState.AddModelError("", "ScreenFrequencyId    is required");
            if (parametr.TeyinatId == 0) ModelState.AddModelError("", "Teyinat    is required");
            if (parametr.VideokartId == 0) ModelState.AddModelError("", "Videokart    is required");
            if (parametr.VideokartRamId == 0) ModelState.AddModelError("", "Videokart Ram    is required");

            //if (model.Id == 0) ModelState.AddModelError("", "Model is required");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePostDto createVM)
        {
            CreateViewModel getCreateVM = _createViewModel(_context);

            ///Required
            IsRequired(createVM.Product, createVM.CategoryBrand, createVM.ProductParametr, createVM.Model);

            if (!ModelState.IsValid) return View(getCreateVM);

            using var transaction = await _context.Database.BeginTransactionAsync();

            //daxili yaddas
            var daxiliYaddas = await _productCreate.CreateDY(createVM);

            //create ProductParametr
            var parametr = await _productCreate.CreatePP(createVM, daxiliYaddas);

            ////Product update
            _productCreate.ProductUpdate(createVM.Product, createVM, parametr);

            //Check
            _productCreate.PosterCheck(createVM.Product);
            _productCreate.ImagesCheck(createVM.Product);

            if (!ModelState.IsValid) return View(getCreateVM);

            //Create
            _productCreate.CreateImage(createVM.Product, true);
            _productCreate.CreateImage(createVM.Product, false);

            //addProduct
            _productCreate.SaveChange(createVM.Product);
            SaveContext();

            await transaction.CommitAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Manage/Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (!CompanyExists(id)) return RedirectToAction("notfound", "error");
            var company = await _context.Products.Include(x => x.ProductImages).FirstOrDefaultAsync(x => x.Id == id);
            return View(company);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!CompanyExists(product.Id)) return RedirectToAction("notfound", "error");

            Product productExist = await _context.Products.Include(x => x.ProductImages).FirstOrDefaultAsync(x => x.Id == product.Id);
            if (productExist.Name != product.Name && _context.Products.Any(x => x.Name == product.Name))
            {
                ModelState.AddModelError("Name", "Name is already!");
                return View(productExist);
            }
            //Required
            EditIsRequired(product);
            if (!ModelState.IsValid) return View(productExist);

            if (product.PosterImageFile != null)
            {
                PosterImageCheck(product);
                if (!ModelState.IsValid) return View(productExist);
                EditPosterImageSave(product, productExist);
            }
            //ImagesDelete
            ImagesDelete(product, productExist);
            if (product.ImageFiles != null) EditImageSave(product, productExist);
            //var viewCount = await _context.ViewCounts.FirstOrDefaultAsync(x => x.ClickName == companyExist.Name);
            EditChange(product, productExist /*viewCount*/);
            SaveContext();
            return RedirectToAction(nameof(Index));

        }

        // GET: Manage/Product/Delete/5
        public IActionResult Delete(int id)
        {
            var products = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);
            if (products == null) return RedirectToAction("notfound", "error");
            var PosterImage = products.ProductImages.FirstOrDefault(x => x.PosterStatus == true);
            FileManager.Delete(_env.WebRootPath, "uploads/product", PosterImage.Image);
            _context.ProductImages.Remove(PosterImage);
            var Images = products.ProductImages.FirstOrDefault(x => x.PosterStatus == false);
            foreach (var item in products.ProductImages.Where(x => x.PosterStatus == false))
            {
                FileManager.Delete(_env.WebRootPath, "uploads/product", item.Image);
                _context.ProductImages.Remove(item);
            }
            _context.SaveChanges();
            _context.Products.Remove(products);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        private CreateViewModel _createViewModel(DataContext _context)
        {
            CreateViewModel createVM = new CreateViewModel
            {
                Product = new Product(),
                ProductParametrs = _context.ProductParametrs.ToList(),
                CategoryBrandIds = _context.CategoryBrandIds.ToList(),
                CategoryBrand = new CategoryBrandId(),
                Categorys = _context.Categories.ToList(),
                ProductParametr = new ProductParametr(),
                Colors = _context.Colors.ToList(),
                Models = _context.Models.ToList(),
                Model = new Model(),
                SSDHecms = _context.SSDHecms.ToList(),
                ProcessorCaches = _context.ProcessorCache.ToList(),
                HDDHecms = _context.HDDHecms.ToList(),
                OperationSystems = _context.OperationSystems.ToList(),
                DaxiliYaddaşs = _context.DaxiliYaddaşs.ToList(),
                ScreenDiagonals = _context.ScreenDiagonals.ToList(),
                RamDDRs = _context.RamDDRs.ToList(),
                Brands = _context.Brands.ToList(),
                ProcessorGhzs = _context.ProcessorGhz.ToList(),
                ProcessorModels = _context.ProcessorModel.ToList(),
                RamGBs = _context.RamGBs.ToList(),
                RamMhzs = _context.RamMhzs.ToList(),
                ScreenFrequencies = _context.ScreenFrequencies.ToList(),
                VideokartRams = _context.VideokartRams.ToList(),
                Teyinats = _context.Teyinats.ToList(),
                Videokarts = _context.Videokarts.ToList(),
                GörüntüImkanıs = _context.GörüntüImkanıs.ToList(),
                SSDTypes = _context.SSDTypes.ToList(),
            };
            return createVM;
        }
        private bool CompanyExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
        private void EditIsRequired(Product product)
        {
            if (product.Name == null)
            {
                ModelState.AddModelError("Name", "Name is required");
            }

        }
        private void PosterImageCheck(Product product)
        {
            if (product.PosterImageFile.ContentType != "image/png" && product.PosterImageFile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("PosterImageFile", "Image type only (png and jpeg");
            }
            if (product.PosterImageFile.Length > 2097152)
            {
                ModelState.AddModelError("PosterImageFile", "PosterImageFile max size is 2MB");
            }
        }
        private void ImagesCheck(Product product)
        {
            foreach (var image in product.ImageFiles)
            {
                if (image.ContentType != "image/png" && image.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFiles", "PosterImageFile is required");
                    break;
                }
                if (image.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFiles", "PosterImageFile max size is 2MB");
                    break;
                }
            }
        }

        private void CreatePosterImage(Product product)
        {
            ProductImage Posterimage = new ProductImage
            {
                PosterStatus = true,
                Product = product,

                Image = FileSave(product),
            };
            _context.ProductImages.Add(Posterimage);
        }
        private string FileSave(Product product)
        {
            string image = FileManager.Save(_env.WebRootPath, "uploads/product", product.PosterImageFile);
            return image;
        }
        private void EditImageSave(Product product, Product productExist)
        {
            foreach (var image in product.ImageFiles)
            {
                if (image.ContentType != "image/png" && image.ContentType != "image/jpeg")
                {
                    continue;
                }
                if (image.Length > 2097152)
                {
                    continue;
                }

                ProductImage newImage = new ProductImage
                {
                    PosterStatus = false,
                    Image = FileManager.Save(_env.WebRootPath, "uploads/product", image),

                };
                if (productExist.ProductImages == null)
                {
                    productExist.ProductImages = new List<ProductImage>();
                }
                productExist.ProductImages.Add(newImage);
            }

        }

        private void CreateImage(Product product)
        {
            ProductImage image = new ProductImage
            {
                PosterStatus = false,
                Product = product,
                Image = FileSave(product),
            };
            _context.ProductImages.Add(image);
        }

        private void EditChange(Product newProduct, Product oldProduct)
        {
            oldProduct.Name = newProduct.Name;

        }
        private void SaveContext()
        {
            _context.SaveChanges();
        }
        private void SaveChange(Product product)
        {
            _context.Add(product);
        }
        private void DeleteFile(string image)
        {
            FileManager.Delete(_env.WebRootPath, "uploads/product", image);
        }
        private void ImagesDelete(Product company, Product companyExist)
        {
            if (company.ProductImagesIds != null)
            {
                foreach (var item in companyExist.ProductImages.Where(x => x.PosterStatus == false && !company.ProductImagesIds.Contains(x.Id)))
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/product", item.Image);
                }
                companyExist.ProductImages.RemoveAll(x => x.PosterStatus == false && !company.ProductImagesIds.Contains(x.Id));

            }
            else
            {
                foreach (var item in companyExist.ProductImages.Where(x => x.PosterStatus == false))
                {
                    DeleteFile(item.Image);
                }
                companyExist.ProductImages.RemoveAll(x => x.PosterStatus == false);
            }
        }
        private void EditPosterImageSave(Product company, Product companyExist)
        {
            var posterFile = company.PosterImageFile;
            ProductImage posterImage = companyExist.ProductImages.FirstOrDefault(x => x.PosterStatus == true);

            var filename = FileSave(company);
            DeleteFile(companyExist.ProductImages.FirstOrDefault(x => x.PosterStatus == true).Image);
            posterImage.Image = filename;
        }
        public ActionResult GetBrand(int categoryId)
        {
            var brands = _context.CategoryBrandIds.Include(x => x.Brand).Where(x => x.CategoryId == categoryId).Select(x => x.Brand);

            return Json(brands.ToList());
        }
        public ActionResult GetModel(int brandId)
        {
            var models = _context.Models.Where(x => x.BrandId == brandId);
            return Json(models.ToList());
        }
    }
}
