using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.Models;
using CompStore.Service.Helper;
using CompStore.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ModelController : Controller
    {
        private readonly DataContext _context;
        private readonly IModelCreateServices _ModelCreateServices;
        private readonly IModelDeleteServices _ModelDeleteServices;
        private readonly IModelEditServices _ModelEditServices;
        private readonly IModelIndexServices _ModelIndexServices;

        public ModelController(DataContext context, IModelCreateServices ModelCreateServices, IModelDeleteServices ModelDeleteServices, IModelEditServices ModelEditServices, IModelIndexServices ModelIndexServices)
        {
            _context = context;
            _ModelCreateServices = ModelCreateServices;
            _ModelDeleteServices = ModelDeleteServices;
            _ModelEditServices = ModelEditServices;
            _ModelIndexServices = ModelIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var Models = await _ModelIndexServices.SearchCheck(search);

            ModelIndexViewModel ModelIndexVM = new ModelIndexViewModel
            {
                PagenatedItems = PagenetedList<Model>.Create(Models, page, 2),
            };

            return View(ModelIndexVM);
        }
        public IActionResult Create()
        {
            ModelCreateDto createDto = new ModelCreateDto
            {
                CategoryBrandIds = _context.CategoryBrandIds.Include(x => x.Category).Include(x => x.Brand).ToList(),
                Brands = _context.Brands.ToList(),
                Model = new Model(),
            };
            return View(createDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModelCreateDto createDto)
        {
            ModelCreateDto createDtoPost = new ModelCreateDto
            {
                CategoryBrandIds = _context.CategoryBrandIds.Include(x => x.Category).Include(x => x.Brand).ToList(),
                Brands = _context.Brands.ToList(),
                Model = new Model(),
            };

            try
            {
                await _ModelCreateServices.ModelCreate(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(createDtoPost);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "Model");
        }

        public async Task<IActionResult> Edit(int id)
        {
            ModelEditDto editDto = new ModelEditDto
            {
                CategoryBrandIds = _context.CategoryBrandIds.Include(x => x.Category).Include(x => x.Brand).ToList(),
                Brands = _context.Brands.ToList(),
                Model = _context.Models.Include(x => x.CategoryBrandId.Brand).Include(x => x.CategoryBrandId.Category).Include(x => x.Brand).FirstOrDefault(x => x.Id == id),
            };

            try
            {
                await _ModelEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(editDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ModelEditDto ModelEdit)
        {
            ModelEditDto createDto = new ModelEditDto
            {
                CategoryBrandIds = _context.CategoryBrandIds.Include(x => x.Category).Include(x => x.Brand).ToList(),
                Brands = _context.Brands.ToList(),
                Model = _context.Models.Include(x => x.CategoryBrandId.Brand).Include(x => x.CategoryBrandId.Category).Include(x => x.Brand).FirstOrDefault(x => x.Id == ModelEdit.Model.Id),
            };

            try
            {
                await _ModelEditServices.ModelEdit(ModelEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(createDto);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "Model");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ModelDeleteServices.ModelDelete(id);
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
