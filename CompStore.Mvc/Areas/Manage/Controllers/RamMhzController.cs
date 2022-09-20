
using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.RamMhzs;
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
    public class RamMhzController : Controller
    {
        private readonly DataContext _context;
        private readonly IRamMhzCreateServices _ramMhzCreateServices;
        private readonly IRamMhzDeleteServices _ramMhzDeleteServices;
        private readonly IRamMhzEditServices _ramMhzEditServices;
        private readonly IRamMhzIndexServices _ramMhzIndexServices;

        public RamMhzController(DataContext context, IRamMhzCreateServices ramMhzCreateServices, IRamMhzDeleteServices ramMhzDeleteServices, IRamMhzEditServices ramMhzEditServices, IRamMhzIndexServices ramMhzIndexServices)
        {
            _context = context;
            _ramMhzCreateServices = ramMhzCreateServices;
            _ramMhzDeleteServices = ramMhzDeleteServices;
            _ramMhzEditServices = ramMhzEditServices;
            _ramMhzIndexServices = ramMhzIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var RamMhzs = await _ramMhzIndexServices.SearchCheck(search);

            RamMhzIndexViewModel RamMhzIndexVM = new RamMhzIndexViewModel
            {
                PagenatedItems = PagenetedList<RamMhz>.Create(RamMhzs, page, 6),
            };

            return View(RamMhzIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RamMhzCreateDto createDto)
        {
            try
            {
                await _ramMhzCreateServices.CreateMhz(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "RamMhz");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _ramMhzEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _ramMhzEditServices.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RamMhzEditDto RamMhzEdit)
        {
            try
            {
                await _ramMhzEditServices.RamMhzEdit(RamMhzEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(RamMhzEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "RamMhz");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ramMhzDeleteServices.RamMhzDelete(id);
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
