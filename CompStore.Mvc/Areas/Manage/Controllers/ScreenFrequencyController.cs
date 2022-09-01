using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.ScreenFrequencys;
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
    public class ScreenFrequencyController : Controller
    {
        private readonly DataContext _context;
        private readonly IScreenFrequencyCreateServices _ScreenFrequencyCreateServices;
        private readonly IScreenFrequencyDeleteServices _ScreenFrequencyDeleteServices;
        private readonly IScreenFrequencyEditServices _ScreenFrequencyEditServices;
        private readonly IScreenFrequencyIndexServices _ScreenFrequencyIndexServices;

        public ScreenFrequencyController(DataContext context,IScreenFrequencyCreateServices ScreenFrequencyCreateServices, IScreenFrequencyDeleteServices ScreenFrequencyDeleteServices,IScreenFrequencyEditServices ScreenFrequencyEditServices,IScreenFrequencyIndexServices ScreenFrequencyIndexServices)
        {
            _context = context;
            _ScreenFrequencyCreateServices = ScreenFrequencyCreateServices;
            _ScreenFrequencyDeleteServices = ScreenFrequencyDeleteServices;
            _ScreenFrequencyEditServices = ScreenFrequencyEditServices;
            _ScreenFrequencyIndexServices = ScreenFrequencyIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var ScreenFrequencys = await _ScreenFrequencyIndexServices.SearchCheck(search);

            ScreenFrequencyIndexViewModel ScreenFrequencyIndexVM = new ScreenFrequencyIndexViewModel
            {
                PagenatedItems = PagenetedList<ScreenFrequency>.Create(ScreenFrequencys, page, 2),
            };

            return View(ScreenFrequencyIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScreenFrequencyCreateDto createDto)
        {
            try
            {
                await _ScreenFrequencyCreateServices.CreateGB(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "ScreenFrequency");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _ScreenFrequencyEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _ScreenFrequencyEditServices.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ScreenFrequencyEditDto ScreenFrequencyEdit)
        {
            try
            {
                await _ScreenFrequencyEditServices.ScreenFrequencyEdit(ScreenFrequencyEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(ScreenFrequencyEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "ScreenFrequency");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ScreenFrequencyDeleteServices.ScreenFrequencyDelete(id);
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
