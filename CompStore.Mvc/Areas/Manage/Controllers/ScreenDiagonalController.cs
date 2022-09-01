using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.ScreenDiagonals;
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
    public class ScreenDiagonalController : Controller
    {
        private readonly DataContext _context;
        private readonly IScreenDiagonalCreateServices _ScreenDiagonalCreateServices;
        private readonly IScreenDiagonalDeleteServices _ScreenDiagonalDeleteServices;
        private readonly IScreenDiagonalEditServices _ScreenDiagonalEditServices;
        private readonly IScreenDiagonalIndexServices _ScreenDiagonalIndexServices;

        public ScreenDiagonalController(DataContext context, IScreenDiagonalCreateServices ScreenDiagonalCreateServices, IScreenDiagonalDeleteServices ScreenDiagonalDeleteServices, IScreenDiagonalEditServices ScreenDiagonalEditServices, IScreenDiagonalIndexServices ScreenDiagonalIndexServices)
        {
            _context = context;
            _ScreenDiagonalCreateServices = ScreenDiagonalCreateServices;
            _ScreenDiagonalDeleteServices = ScreenDiagonalDeleteServices;
            _ScreenDiagonalEditServices = ScreenDiagonalEditServices;
            _ScreenDiagonalIndexServices = ScreenDiagonalIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var ScreenDiagonals = await _ScreenDiagonalIndexServices.SearchCheck(search);

            ScreenDiagonalIndexViewModel ScreenDiagonalIndexVM = new ScreenDiagonalIndexViewModel
            {
                PagenatedItems = PagenetedList<ScreenDiagonal>.Create(ScreenDiagonals, page, 2),
            };

            return View(ScreenDiagonalIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScreenDiagonalCreateDto createDto)
        {
            try
            {
                await _ScreenDiagonalCreateServices.CreateGB(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "ScreenDiagonal");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _ScreenDiagonalEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _ScreenDiagonalEditServices.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ScreenDiagonalEditDto ScreenDiagonalEdit)
        {
            try
            {
                await _ScreenDiagonalEditServices.ScreenDiagonalEdit(ScreenDiagonalEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(ScreenDiagonalEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "ScreenDiagonal");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ScreenDiagonalDeleteServices.ScreenDiagonalDelete(id);
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
