using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.SSDTypes;
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
    public class SSDTypeController : Controller
    {
        private readonly DataContext _context;
        private readonly ISSDTypeCreateServices _SSDTypeCreateServices;
        private readonly ISSDTypeDeleteServices _SSDTypeDeleteServices;
        private readonly ISSDTypeEditServices _SSDTypeEditServices;
        private readonly ISSDTypeIndexServices _SSDTypeIndexServices;

        public SSDTypeController(DataContext context, ISSDTypeCreateServices SSDTypeCreateServices, ISSDTypeDeleteServices SSDTypeDeleteServices, ISSDTypeEditServices SSDTypeEditServices, ISSDTypeIndexServices SSDTypeIndexServices)
        {
            _context = context;
            _SSDTypeCreateServices = SSDTypeCreateServices;
            _SSDTypeDeleteServices = SSDTypeDeleteServices;
            _SSDTypeEditServices = SSDTypeEditServices;
            _SSDTypeIndexServices = SSDTypeIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var SSDTypes = await _SSDTypeIndexServices.SearchCheck(search);

            SSDTypeIndexViewModel SSDTypeIndexVM = new SSDTypeIndexViewModel
            {
                PagenatedItems = PagenetedList<SSDType>.Create(SSDTypes, page, 6),
            };

            return View(SSDTypeIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SSDTypeCreateDto createDto)
        {
            try
            {
                await _SSDTypeCreateServices.CreateType(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "SSDType");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _SSDTypeEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _SSDTypeEditServices.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SSDTypeEditDto SSDTypeEdit)
        {
            try
            {
                await _SSDTypeEditServices.SSDTypeEdit(SSDTypeEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(SSDTypeEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "SSDType");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _SSDTypeDeleteServices.SSDTypeDelete(id);
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
