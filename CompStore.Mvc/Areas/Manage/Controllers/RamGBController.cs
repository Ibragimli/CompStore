using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.RamGbs;
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
    public class RamGBController : Controller
    {
        private readonly DataContext _context;
        private readonly IRamGBCreateServices _ramGBCreateServices;
        private readonly IRamGBDeleteServices _ramGBDeleteServices;
        private readonly IRamGBEditServices _ramGBEditServices;
        private readonly IRamGBIndexServices _ramGBIndexServices;

        public RamGBController(DataContext context,IRamGBCreateServices ramGBCreateServices, IRamGBDeleteServices ramGBDeleteServices,IRamGBEditServices ramGBEditServices,IRamGBIndexServices ramGBIndexServices)
        {
            _context = context;
            _ramGBCreateServices = ramGBCreateServices;
            _ramGBDeleteServices = ramGBDeleteServices;
            _ramGBEditServices = ramGBEditServices;
            _ramGBIndexServices = ramGBIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var RamGBs = await _ramGBIndexServices.SearchCheck(search);

            RamGBIndexViewModel RamGBIndexVM = new RamGBIndexViewModel
            {
                PagenatedItems = PagenetedList<RamGB>.Create(RamGBs, page, 6),
            };

            return View(RamGBIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RamGBCreateDto createDto)
        {
            try
            {
                await _ramGBCreateServices.CreateGB(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "RamGB");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _ramGBEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _ramGBEditServices.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RamGBEditDto RamGBEdit)
        {
            try
            {
                await _ramGBEditServices.RamGBEdit(RamGBEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(RamGBEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "RamGB");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ramGBDeleteServices.RamGbDelete(id);
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
