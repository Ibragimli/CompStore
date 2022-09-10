using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.Colors;
using CompStore.Service.Helper;
using CompStore.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ColorController : Controller
    {
        private readonly DataContext _context;
        private readonly IColorCreateServices _ColorCreateServices;
        private readonly IColorDeleteServices _ColorDeleteServices;
        private readonly IColorEditServices _ColorEditServices;
        private readonly IColorIndexServices _ColorIndexServices;

        public ColorController(DataContext context, IColorCreateServices ColorCreateServices, IColorDeleteServices ColorDeleteServices, IColorEditServices ColorEditServices, IColorIndexServices ColorIndexServices)
        {
            _context = context;
            _ColorCreateServices = ColorCreateServices;
            _ColorDeleteServices = ColorDeleteServices;
            _ColorEditServices = ColorEditServices;
            _ColorIndexServices = ColorIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var Colors = await _ColorIndexServices.SearchCheck(search);

            ColorIndexViewModel ColorIndexVM = new ColorIndexViewModel
            {
                PagenatedItems = PagenetedList<Color>.Create(Colors, page, 6),
            };

            return View(ColorIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ColorCreateDto createDto)
        {
            try
            {
                await _ColorCreateServices.CreateColor(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "Color");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _ColorEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _ColorEditServices.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ColorEditDto ColorEdit)
        {
            try
            {
                await _ColorEditServices.ColorEdit(ColorEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(ColorEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "Color");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ColorDeleteServices.ColorDelete(id);
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
