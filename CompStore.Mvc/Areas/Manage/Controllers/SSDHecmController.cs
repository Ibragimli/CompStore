using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.SSDHecms;
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
    public class SSDHecmController : Controller
    {
        private readonly DataContext _context;
        private readonly ISSDHecmCreateServices _SSDHecmCreateServices;
        private readonly ISSDHecmDeleteServices _SSDHecmDeleteServices;
        private readonly ISSDHecmEditServices _SSDHecmEditServices;
        private readonly ISSDHecmIndexServices _SSDHecmIndexServices;

        public SSDHecmController(DataContext context, ISSDHecmCreateServices SSDHecmCreateServices, ISSDHecmDeleteServices SSDHecmDeleteServices, ISSDHecmEditServices SSDHecmEditServices, ISSDHecmIndexServices SSDHecmIndexServices)
        {
            _context = context;
            _SSDHecmCreateServices = SSDHecmCreateServices;
            _SSDHecmDeleteServices = SSDHecmDeleteServices;
            _SSDHecmEditServices = SSDHecmEditServices;
            _SSDHecmIndexServices = SSDHecmIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var SSDHecms = await _SSDHecmIndexServices.SearchCheck(search);

            SSDHecmIndexViewModel SSDHecmIndexVM = new SSDHecmIndexViewModel
            {
                PagenatedItems = PagenetedList<SSDHecm>.Create(SSDHecms, page, 6),
            };

            return View(SSDHecmIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SSDHecmCreateDto createDto)
        {
            try
            {
                await _SSDHecmCreateServices.CreateGB(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "SSDHecm");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _SSDHecmEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _SSDHecmEditServices.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SSDHecmEditDto SSDHecmEdit)
        {
            try
            {
                await _SSDHecmEditServices.SSDHecmEdit(SSDHecmEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(SSDHecmEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "SSDHecm");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _SSDHecmDeleteServices.SSDHecmDelete(id);
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233088)
                {
                    TempData["Error"] = ("Daxili Yaddaş modelində istifade olunur deye silmek mümkün olmadı!");
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
