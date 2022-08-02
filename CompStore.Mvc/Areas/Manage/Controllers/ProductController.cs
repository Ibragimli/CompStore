﻿using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.CustomExceptions;
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
        private readonly IProductEditServices _productEdit;
        private readonly IProductDeleteServices _productDelete;

        public ProductController(DataContext context, IWebHostEnvironment env, IProductCreateServices productCreate, IProductEditServices productEdit, IProductDeleteServices productDelete)
        {
            _context = context;
            _env = env;
            _productCreate = productCreate;
            _productEdit = productEdit;
            _productDelete = productDelete;
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePostDto createVM)
        {
            CreateViewModel getCreateVM = _createViewModel(_context);

            ///Required

            if (!ModelState.IsValid) return View(getCreateVM);

            using var transaction = await _context.Database.BeginTransactionAsync();

            //daxili yaddas
            var daxiliYaddas = await _productCreate.CreateDY(createVM);

            //create ProductParametr
            var parametr = await _productCreate.CreatePP(createVM, daxiliYaddas);

            ////Product update
            try
            {
                _productCreate.ProductUpdate(createVM.Product, createVM, parametr);
            }
            catch (FileFormatException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(getCreateVM);
            }

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

            Product productExist = await _productEdit.ExistProduct(product.Id);

            if (!ModelState.IsValid) return View(productExist);


            _productEdit.CheckDaxiliYaddas(product, productExist);
            //AddPosterImage
            _productEdit.AddPosterImage(product, productExist);

            if (!ModelState.IsValid) return View(productExist);

            //ImagesDelete
            try
            {
                _productEdit.DeleteImages(product, productExist);
            }
            catch (ImageCountException ex)
            {
                ModelState.AddModelError("Product.ImageFiles", ex.Message);
                return View(_editProductViewModel(_context, productExist.Id));
            }

            //AddImages
            _productEdit.AddImages(product, productExist);

            //var viewCount = await _context.ViewCounts.FirstOrDefaultAsync(x => x.ClickName == companyExist.Name);

            EditChange(product, productExist /*viewCount*/);
            SaveContext();
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


        private void EditChange(Product newProduct, Product oldProduct)
        {
            oldProduct.Name = newProduct.Name;
            oldProduct.Description = newProduct.Description;
            oldProduct.Price = newProduct.Price;
            oldProduct.DiscountPercent = newProduct.DiscountPercent;
            oldProduct.ModelId = newProduct.ModelId;

            oldProduct.CategoryBrandId.CategoryId = newProduct.CategoryBrandId.CategoryId;
            oldProduct.CategoryBrandId.BrandId = newProduct.CategoryBrandId.BrandId;

            oldProduct.ProductParametr.Kamera = newProduct.ProductParametr.Kamera;
            oldProduct.ProductParametr.Bluetooth = newProduct.ProductParametr.Bluetooth;
            oldProduct.ProductParametr.ColorId = newProduct.ProductParametr.ColorId;
            oldProduct.ProductParametr.GörüntüImkanıId = newProduct.ProductParametr.GörüntüImkanıId;
            oldProduct.ProductParametr.OperationSystemId = newProduct.ProductParametr.OperationSystemId;
            oldProduct.ProductParametr.ProcessorCacheId = newProduct.ProductParametr.ProcessorCacheId;
            oldProduct.ProductParametr.ProcessorGhzId = newProduct.ProductParametr.ProcessorGhzId;
            oldProduct.ProductParametr.ProcessorModelId = newProduct.ProductParametr.ProcessorModelId;
            oldProduct.ProductParametr.RamDDRId = newProduct.ProductParametr.RamDDRId;
            oldProduct.ProductParametr.RamGBId = newProduct.ProductParametr.RamGBId;
            oldProduct.ProductParametr.RamMhzId = newProduct.ProductParametr.RamMhzId;
            oldProduct.ProductParametr.ScreenDiagonalId = newProduct.ProductParametr.ScreenDiagonalId;
            oldProduct.ProductParametr.ScreenFrequencyId = newProduct.ProductParametr.ScreenFrequencyId;
            oldProduct.ProductParametr.TeyinatId = newProduct.ProductParametr.TeyinatId;
            oldProduct.ProductParametr.VideokartId = newProduct.ProductParametr.VideokartId;
            oldProduct.ProductParametr.VideokartRamId = newProduct.ProductParametr.VideokartRamId;
            oldProduct.ProductParametr.TeyinatId = newProduct.ProductParametr.TeyinatId;

            oldProduct.ProductParametr.DaxiliYaddaş.IsHDD = newProduct.ProductParametr.DaxiliYaddaş.IsHDD;
            oldProduct.ProductParametr.DaxiliYaddaş.IsSSD = newProduct.ProductParametr.DaxiliYaddaş.IsSSD;
            if (newProduct.ProductParametr.DaxiliYaddaş.IsSSD)
            {
                oldProduct.ProductParametr.DaxiliYaddaş.SSDHecmId = newProduct.ProductParametr.DaxiliYaddaş.SSDHecmId;
                oldProduct.ProductParametr.DaxiliYaddaş.SSDTypeId = newProduct.ProductParametr.DaxiliYaddaş.SSDTypeId;
            }

            if (newProduct.ProductParametr.DaxiliYaddaş.IsHDD)
                oldProduct.ProductParametr.DaxiliYaddaş.HDDHecmId = newProduct.ProductParametr.DaxiliYaddaş.HDDHecmId;

            oldProduct.ProductParametr.DaxiliYaddaş.ModifiedDate = DateTime.UtcNow.AddHours(4); ;
            oldProduct.ModifiedDate = DateTime.UtcNow.AddHours(4);
            oldProduct.ProductParametr.ModifiedDate = DateTime.UtcNow.AddHours(4);
            oldProduct.CategoryBrandId.ModifiedDate = DateTime.UtcNow.AddHours(4);

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
