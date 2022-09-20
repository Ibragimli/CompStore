using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.CategoryBrandIds;
using CompStore.Service.Helper;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Areas.Manage.Controllers
{
    [Area("manage")]
    public class CategoryBrandIdController : Controller
    {
        private readonly DataContext _context;
        private readonly ICategoryBrandIdCreateServices _CategoryBrandIdCreateServices;
        private readonly ICategoryBrandIdDeleteServices _CategoryBrandIdDeleteServices;
        private readonly ICategoryBrandIdEditServices _CategoryBrandIdEditServices;
        private readonly ICategoryBrandIdIndexServices _CategoryBrandIdIndexServices;

        public CategoryBrandIdController(DataContext context, ICategoryBrandIdCreateServices CategoryBrandIdCreateServices, ICategoryBrandIdDeleteServices CategoryBrandIdDeleteServices, ICategoryBrandIdEditServices CategoryBrandIdEditServices, ICategoryBrandIdIndexServices CategoryBrandIdIndexServices)
        {
            _context = context;
            _CategoryBrandIdCreateServices = CategoryBrandIdCreateServices;
            _CategoryBrandIdDeleteServices = CategoryBrandIdDeleteServices;
            _CategoryBrandIdEditServices = CategoryBrandIdEditServices;
            _CategoryBrandIdIndexServices = CategoryBrandIdIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {

            ViewBag.Page = page;
            var CategoryBrandIds = await _CategoryBrandIdIndexServices.SearchCheck(search);

            CategoryBrandIdIndexViewModel CategoryBrandIdIndexVM = new CategoryBrandIdIndexViewModel
            {
                PagenatedItems = PagenetedList<CategoryBrandId>.Create(CategoryBrandIds, page, 6),
            };

            return View(CategoryBrandIdIndexVM);
        }
        public IActionResult Create()
        {
            CategoryBrandIdCreateDto categoryBrandIdCreate = new CategoryBrandIdCreateDto
            {
                Brands = _context.Brands.ToList(),
                Categories = _context.Categories.ToList(),
                CategoryBrandId = new CategoryBrandId(),
            };
            return View(categoryBrandIdCreate);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryBrandIdCreateDto createDto)
        {
            CategoryBrandIdCreateDto categoryBrandIdCreate = new CategoryBrandIdCreateDto
            {
                Brands = _context.Brands.ToList(),
                Categories = _context.Categories.ToList(),
                CategoryBrandId = new CategoryBrandId(),
            };
            try
            {
                await _CategoryBrandIdCreateServices.CreateGB(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(categoryBrandIdCreate);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "CategoryBrandId");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _CategoryBrandIdEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }
            CategoryBrandIdEditDto categoryBrandIdEditDto = new CategoryBrandIdEditDto
            {
                Brands = _context.Brands.ToList(),
                Categories = _context.Categories.ToList(),
                CategoryBrandId = await _context.CategoryBrandIds.FirstOrDefaultAsync(x => x.Id == id),
            };

            return View(categoryBrandIdEditDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryBrandIdEditDto CategoryBrandIdEdit)
        {
            CategoryBrandIdEditDto categoryBrandIdEditDto = new CategoryBrandIdEditDto
            {
                Brands = _context.Brands.ToList(),
                Categories = _context.Categories.ToList(),
                CategoryBrandId = CategoryBrandIdEdit.CategoryBrandId,
            };
            try
            {
                await _CategoryBrandIdEditServices.CategoryBrandIdEdit(CategoryBrandIdEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(categoryBrandIdEditDto);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "CategoryBrandId");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _CategoryBrandIdDeleteServices.CategoryBrandIdDelete(id);
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233088)
                {
                    TempData["Error"] = ("Product Parametr model də istifade olunur deye silmek mümkün olmadı!");
                    return RedirectToAction(nameof(Index));
                }

                TempData["Error"] = ("Proses uğursuz oldu!");
                return RedirectToAction(nameof(Index));
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction(nameof(Index));
        }

    }
}
