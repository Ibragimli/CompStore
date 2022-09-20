using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.Categorys;
using CompStore.Service.Helper;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Areas.Manage.Controllers
{
    [Area("manage")]
    public class CategoryController : Controller
    {
        private readonly DataContext _context;
        private readonly ICategoryCreateServices _CategoryCreateServices;
        private readonly ICategoryDeleteServices _CategoryDeleteServices;
        private readonly ICategoryEditServices _CategoryEditServices;
        private readonly ICategoryIndexServices _CategoryIndexServices;

        public CategoryController(DataContext context, ICategoryCreateServices CategoryCreateServices, ICategoryDeleteServices CategoryDeleteServices, ICategoryEditServices CategoryEditServices, ICategoryIndexServices CategoryIndexServices)
        {
            _context = context;
            _CategoryCreateServices = CategoryCreateServices;
            _CategoryDeleteServices = CategoryDeleteServices;
            _CategoryEditServices = CategoryEditServices;
            _CategoryIndexServices = CategoryIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var Categorys = await _CategoryIndexServices.SearchCheck(search);

            CategoryIndexViewModel CategoryIndexVM = new CategoryIndexViewModel
            {
                PagenatedItems = PagenetedList<Category>.Create(Categorys, page, 6),
            };

            return View(CategoryIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateDto createDto)
        {
            try
            {
                await _CategoryCreateServices.CreateGB(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "Category");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _CategoryEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _CategoryEditServices.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryEditDto CategoryEdit)
        {
            try
            {
                await _CategoryEditServices.CategoryEdit(CategoryEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(CategoryEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "Category");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _CategoryDeleteServices.CategoryDelete(id);
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233088)
                {
                    TempData["Error"] = ("CategoryBrand model də istifade olunur deye silmek mümkün olmadı!");
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
