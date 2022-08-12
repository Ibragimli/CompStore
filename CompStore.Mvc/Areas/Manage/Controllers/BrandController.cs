using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos;
using CompStore.Service.Dtos.Area.Brands;
using CompStore.Service.Helper;
using CompStore.Service.Services.Implementations;
using CompStore.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Areas.Manage.Controllers
{
    [Area("manage")]
    public class BrandController : Controller
    {
        private readonly DataContext _context;
        private readonly IBrandIndexServices _brandIndexServices;
        private readonly IBrandCreateServices _brandCreate;
        private readonly IBrandDeleteServices _brandDelete;
        private readonly IBrandEditServices _brandEdit;

        public BrandController(DataContext context, IBrandIndexServices brandIndexServices, IBrandCreateServices brandCreate, IBrandDeleteServices brandDelete, IBrandEditServices brandEdit)
        {
            _context = context;
            _brandIndexServices = brandIndexServices;
            _brandCreate = brandCreate;
            _brandDelete = brandDelete;
            _brandEdit = brandEdit;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var brands = await _brandIndexServices.SearchCheck(search);

            BrandIndexViewModel brandIndexVM = new BrandIndexViewModel
            {
                PagenatedItems = PagenetedList<Brand>.Create(brands, page, 2),
            };

            return View(brandIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandCreateDto createDto)
        {
            try
            {
                await _brandCreate.CreateBrand(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "brand");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _brandEdit.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _brandEdit.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BrandEditDto brandEdit)
        {
            try
            {
                await _brandEdit.BrandEdit(brandEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(brandEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "brand");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _brandDelete.BrandDelete(id);
            }
            catch (ItemNotFoundException ex)
            {
                TempData["Error"] = ("Proses uğursuz oldu!");
                return RedirectToAction(nameof(Index));
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction(nameof(Index));
        }
    }
}
