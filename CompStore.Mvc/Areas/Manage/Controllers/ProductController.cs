using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Helper;
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

        public ProductController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Manage/Companies
        public IActionResult Index(int page = 1)
        {
            var products = _context.Products.Include(x => x.ProductImages).AsQueryable();
            ProductIndexViewModel productIndexVM = new ProductIndexViewModel
            {
                PagenatedProducts = PagenetedList<Product>.Create(products, page, 8),
            };
            return View(productIndexVM);
        }


        // GET: Manage/Companies/Create
        public IActionResult Create()
        {
            CreateViewModel createVM = new CreateViewModel
            {
                Product = new Product(),
                Categorys = _context.Categories.ToList(),
                ProductParametrs = _context.ProductParametrs.ToList(),
                ProductParametr = new ProductParametr(),
                Colors = _context.Colors.ToList(),
                Models = _context.Models.ToList(),
                ProcessorCaches = _context.ProcessorCache.ToList(),
                DaxiliYaddasHecms = _context.DaxiliYaddasHecms.ToList(),
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
            };
            return View(createVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateViewModel createVM)
        {
            ///Required
            //IsRequired(createVM);
            //if (_context.Products.Any(x => x.Name == createVM.Name))
            //{
            //    ModelState.AddModelError("Name", "Name is already!");
            //    return View();
            //}
            //if (!ModelState.IsValid) return View();

            ////Check
            //PosterImageCheck(product);
            //ImagesCheck(product);
            //if (!ModelState.IsValid) return View();

            ////Create
            //CreatePosterImage(product);
            //CreateImage(product);


            //ViewCount count = new ViewCount
            //{
            //    ClickName = company.Name,
            //    Count = 0,
            //};
            //_context.ViewCounts.Add(count);
            //SaveChange
            //SaveChange(product);
            SaveContext();
            return RedirectToAction(nameof(Index));
        }

        // GET: Manage/Companies/Edit/5
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

        // GET: Manage/Companies/Delete/5
        public IActionResult Delete(int id)
        {
            var company = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);
            if (company == null) return RedirectToAction("notfound", "error");
            //var PosterImage = company.ProductImages.FirstOrDefault(x => x.PosterStatus == true);
            //FileManager.Delete(_env.WebRootPath, "uploads/companies", PosterImage.Image);

            //var Images = company.ProductImages.FirstOrDefault(x => x.PosterStatus == false);
            //foreach (var item in company.ProductImages.Where(x => x.PosterStatus == false))
            //{
            //    DeleteFile(item);
            //}
            //_context.Companies.Remove(company);
            return RedirectToAction(nameof(Index));
        }


        private bool CompanyExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
        private void IsRequired(Product product)
        {
            if (product.Name == null)
            {
                ModelState.AddModelError("Name", "Name is required");
            }

            if (product.Price == null)
            {
                ModelState.AddModelError("Website", "Website is required");

            }
            if (product.Description == null)
            {
                ModelState.AddModelError("Description", "Description is required");

            }

            if (product.PosterImageFile == null)
            {
                ModelState.AddModelError("PosterImageFile", "PosterImageFile is required");

            }
            if (product.ImageFiles == null)
            {
                ModelState.AddModelError("ImageFiles", "ImageFiles is required");

            }
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
            string image = FileManager.Save(_env.WebRootPath, "uploads/companies", product.PosterImageFile);
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
                    Image = FileManager.Save(_env.WebRootPath, "uploads/companies", image),

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
            FileManager.Delete(_env.WebRootPath, "uploads/companies", image);
        }
        private void ImagesDelete(Product company, Product companyExist)
        {
            if (company.ProductImagesIds != null)
            {
                foreach (var item in companyExist.ProductImages.Where(x => x.PosterStatus == false && !company.ProductImagesIds.Contains(x.Id)))
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/companies", item.Image);
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
    }
}
