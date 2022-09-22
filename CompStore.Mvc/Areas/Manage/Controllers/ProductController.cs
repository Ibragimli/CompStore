using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.Products;
using CompStore.Service.Helper;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
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
        private readonly IProductIndexServices _productIndex;
        private readonly IProductCreateServices _productCreate;
        private readonly IProductEditServices _productEdit;
        private readonly IProductDeleteServices _productDelete;
        private readonly IProductDetailServices _detailServices;

        public ProductController(DataContext context, IWebHostEnvironment env, IProductIndexServices productIndex, IProductCreateServices productCreate, IProductEditServices productEdit, IProductDeleteServices productDelete, IProductDetailServices detailServices)
        {
            _context = context;
            _env = env;
            _productIndex = productIndex;
            _productCreate = productCreate;
            _productEdit = productEdit;
            _productDelete = productDelete;
            _detailServices = detailServices;
        }

        // GET: Manage/Product
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var products = _productIndex.SearchCheck(search);

            ProductIndexViewModel productIndexVM = new ProductIndexViewModel
            {
                PagenatedProducts = PagenetedList<Product>.Create(await products, page, 6),
            };
            return View(productIndexVM);
        }

        public async Task<IActionResult> Detail(int id)
        {

            try
            {
                await _detailServices.isProduct(id);
            }
            catch (ItemNotFoundException)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _detailServices.isProduct(id));

        }

        // GET: Manage/Product/Create
        public IActionResult Create()
        {
            return View(_createViewModel(_context));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePostDto createVM)
        {
            CreateViewModel getCreateVM = _createViewModel(_context);

            ///Required

            if (!ModelState.IsValid) return View(getCreateVM);

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {

                //daxili yaddas
                var daxiliYaddas = await _productCreate.CreateDY(createVM);

                //create ProductParametr
                var parametr = await _productCreate.CreatePP(createVM, daxiliYaddas);

                ////Product update
                _productCreate.ProductUpdate(createVM.Product, createVM, parametr);

                //Check
                _productCreate.PosterCheck(createVM.Product);
                _productCreate.ImagesCheck(createVM.Product);

                //Create
                _productCreate.CreateImage(createVM.Product, true);
                _productCreate.CreateImage(createVM.Product, false);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                TempData["Error"] = ("Proses uğursuz oldu!");
                return View(getCreateVM);
            }

            //addProduct
            _productCreate.SaveChange(createVM.Product);
            SaveContext();
            await transaction.CommitAsync();
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction(nameof(Index));
        }

        // GET: Manage/Product/Edit/5
        public IActionResult Edit(int id)
        {
            var editVM = _editProductViewModel(_context, id);
            return View(editVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditPostDto editDto)
        {
            var product = editDto.Product;

            if (await _productEdit.IsExistProduct(product.Id) == false) return RedirectToAction("notfound", "error");

            EditPostDto editPostExist = new EditPostDto { Product = await _productEdit.ExistProduct(product.Id) };

            if (!ModelState.IsValid) return View(_editProductViewModel(_context, editPostExist.Product.Id));

            try
            {

                //DaxiliYaddasCheck
                _productEdit.CheckDaxiliYaddas(product, editPostExist.Product);
                //AddPosterImage
                _productEdit.AddPosterImage(product, editPostExist.Product);
                //ImagesDelete
                _productEdit.DeleteImages(product, editPostExist.Product);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                TempData["Error"] = ("Proses uğursuz oldu!");
                return View(_editProductViewModel(_context, editPostExist.Product.Id));
            }


            //AddImages
            _productEdit.AddImages(product, editPostExist.Product);

            //var viewCount = await _context.ViewCounts.FirstOrDefaultAsync(x => x.ClickName == companyExist.Name);

            EditChange(product, editPostExist /*viewCount*/);
            SaveContext();
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction(nameof(Index));
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Product productExist = await _context.Products.Include(x => x.ProductImages).Include(x => x.ProductParametr).ThenInclude(x => x.DaxiliYaddaş).FirstOrDefaultAsync(x => x.Id == id);

            _productDelete.PosterImageDelete(productExist);

            _productDelete.ImagesDelete(productExist);

            if (!await _productDelete.DaxiliYaddasDelete(productExist))
                return RedirectToAction("notfound", "error");

            if (!await _productDelete.ProductParametrDelete(productExist))
                return RedirectToAction("notfound", "error");

            _productDelete.ProductDelete(productExist);

            SaveContext();
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction(nameof(Index));
        }

        private CreateViewModel _createViewModel(DataContext _context)
        {
            CreateViewModel createVM = new CreateViewModel
            {
                Product = new Product(),
                CategoryBrandIds = _context.CategoryBrandIds.ToList(),
                CategoryBrand = new CategoryBrandId(),
                ProductParametr = new ProductParametr(),
                viewModel = ViewModel(),
            };
            return createVM;
        }
        private EditProductViewModel _editProductViewModel(DataContext _context, int id)
        {
            EditProductViewModel editVM = new EditProductViewModel
            {
                Product = _context.Products.Include(x => x.ProductImages).Include(x => x.Model).Include(x => x.ProductParametr).ThenInclude(x => x.DaxiliYaddaş).FirstOrDefault(x => x.Id == id),
                viewModel = ViewModel(),
            };
            return editVM;
        }
        private EditCreateViewModel ViewModel()
        {
            EditCreateViewModel editCreate = new EditCreateViewModel
            {
                ProductParametrs = _context.ProductParametrs.ToList(),
                CategoryBrandIds = _context.CategoryBrandIds.ToList(),
                Categorys = _context.Categories.ToList(),
                Colors = _context.Colors.ToList(),
                Models = _context.Models.ToList(),
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
            return editCreate;
        }


        private void EditChange(Product newProduct, EditPostDto oldProduct)
        {
            oldProduct.Product.Name = newProduct.Name;
            oldProduct.Product.Description = newProduct.Description;
            oldProduct.Product.Price = newProduct.Price;
            oldProduct.Product.DiscountPercent = newProduct.DiscountPercent;
            oldProduct.Product.ModelId = newProduct.ModelId;
            oldProduct.Product.IsFeatured = newProduct.IsFeatured;

            var categoryBrand = _context.CategoryBrandIds.FirstOrDefault(x => x.CategoryId == newProduct.CategoryBrandId.CategoryId && x.BrandId == newProduct.CategoryBrandId.BrandId);
            if (categoryBrand != null)
                oldProduct.Product.CategoryBrandIdId = categoryBrand.Id;

            oldProduct.Product.ProductParametr.Kamera = newProduct.ProductParametr.Kamera;
            oldProduct.Product.ProductParametr.Bluetooth = newProduct.ProductParametr.Bluetooth;
            oldProduct.Product.ProductParametr.ColorId = newProduct.ProductParametr.ColorId;
            oldProduct.Product.ProductParametr.GörüntüImkanıId = newProduct.ProductParametr.GörüntüImkanıId;
            oldProduct.Product.ProductParametr.OperationSystemId = newProduct.ProductParametr.OperationSystemId;
            oldProduct.Product.ProductParametr.ProcessorCacheId = newProduct.ProductParametr.ProcessorCacheId;
            oldProduct.Product.ProductParametr.ProcessorGhzId = newProduct.ProductParametr.ProcessorGhzId;
            oldProduct.Product.ProductParametr.ProcessorModelId = newProduct.ProductParametr.ProcessorModelId;
            oldProduct.Product.ProductParametr.RamDDRId = newProduct.ProductParametr.RamDDRId;
            oldProduct.Product.ProductParametr.RamGBId = newProduct.ProductParametr.RamGBId;
            oldProduct.Product.ProductParametr.RamMhzId = newProduct.ProductParametr.RamMhzId;
            oldProduct.Product.ProductParametr.ScreenDiagonalId = newProduct.ProductParametr.ScreenDiagonalId;
            oldProduct.Product.ProductParametr.ScreenFrequencyId = newProduct.ProductParametr.ScreenFrequencyId;
            oldProduct.Product.ProductParametr.TeyinatId = newProduct.ProductParametr.TeyinatId;
            oldProduct.Product.ProductParametr.VideokartId = newProduct.ProductParametr.VideokartId;
            oldProduct.Product.ProductParametr.VideokartRamId = newProduct.ProductParametr.VideokartRamId;
            oldProduct.Product.ProductParametr.TeyinatId = newProduct.ProductParametr.TeyinatId;

            oldProduct.Product.ProductParametr.DaxiliYaddaş.IsHDD = newProduct.ProductParametr.DaxiliYaddaş.IsHDD;
            oldProduct.Product.ProductParametr.DaxiliYaddaş.IsSSD = newProduct.ProductParametr.DaxiliYaddaş.IsSSD;
            if (newProduct.ProductParametr.DaxiliYaddaş.IsSSD)
            {
                oldProduct.Product.ProductParametr.DaxiliYaddaş.SSDHecmId = newProduct.ProductParametr.DaxiliYaddaş.SSDHecmId;
                oldProduct.Product.ProductParametr.DaxiliYaddaş.SSDTypeId = newProduct.ProductParametr.DaxiliYaddaş.SSDTypeId;
            }

            if (newProduct.ProductParametr.DaxiliYaddaş.IsHDD)
                oldProduct.Product.ProductParametr.DaxiliYaddaş.HDDHecmId = newProduct.ProductParametr.DaxiliYaddaş.HDDHecmId;

            oldProduct.Product.ProductParametr.DaxiliYaddaş.ModifiedDate = DateTime.UtcNow.AddHours(4); ;
            oldProduct.Product.ModifiedDate = DateTime.UtcNow.AddHours(4);
            oldProduct.Product.ProductParametr.ModifiedDate = DateTime.UtcNow.AddHours(4);

        }
        private void SaveContext()
        {
            _context.SaveChanges();
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
