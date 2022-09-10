using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.Teyinats;
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
    public class TeyinatController : Controller
    {
        private readonly DataContext _context;
        private readonly ITeyinatCreateServices _TeyinatCreateServices;
        private readonly ITeyinatDeleteServices _TeyinatDeleteServices;
        private readonly ITeyinatEditServices _TeyinatEditServices;
        private readonly ITeyinatIndexServices _TeyinatIndexServices;

        public TeyinatController(DataContext context, ITeyinatCreateServices TeyinatCreateServices, ITeyinatDeleteServices TeyinatDeleteServices, ITeyinatEditServices TeyinatEditServices, ITeyinatIndexServices TeyinatIndexServices)
        {
            _context = context;
            _TeyinatCreateServices = TeyinatCreateServices;
            _TeyinatDeleteServices = TeyinatDeleteServices;
            _TeyinatEditServices = TeyinatEditServices;
            _TeyinatIndexServices = TeyinatIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var Teyinats = await _TeyinatIndexServices.SearchCheck(search);

            TeyinatIndexViewModel TeyinatIndexVM = new TeyinatIndexViewModel
            {
                PagenatedItems = PagenetedList<Teyinat>.Create(Teyinats, page, 6),
            };

            return View(TeyinatIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeyinatCreateDto createDto)
        {
            try
            {
                await _TeyinatCreateServices.CreateTeyinat(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "Teyinat");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _TeyinatEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _TeyinatEditServices.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TeyinatEditDto TeyinatEdit)
        {
            try
            {
                await _TeyinatEditServices.TeyinatEdit(TeyinatEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(TeyinatEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "Teyinat");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _TeyinatDeleteServices.TeyinatDelete(id);
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
