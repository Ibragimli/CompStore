using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.HDDHecms;
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
    public class HDDHecmController : Controller
    {
        private readonly DataContext _context;
        private readonly IHDDHecmCreateServices _HDDHecmCreateServices;
        private readonly IHDDHecmDeleteServices _HDDHecmDeleteServices;
        private readonly IHDDHecmEditServices _HDDHecmEditServices;
        private readonly IHDDHecmIndexServices _HDDHecmIndexServices;

        public HDDHecmController(DataContext context, IHDDHecmCreateServices HDDHecmCreateServices, IHDDHecmDeleteServices HDDHecmDeleteServices, IHDDHecmEditServices HDDHecmEditServices, IHDDHecmIndexServices HDDHecmIndexServices)
        {
            _context = context;
            _HDDHecmCreateServices = HDDHecmCreateServices;
            _HDDHecmDeleteServices = HDDHecmDeleteServices;
            _HDDHecmEditServices = HDDHecmEditServices;
            _HDDHecmIndexServices = HDDHecmIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var HDDHecms = await _HDDHecmIndexServices.SearchCheck(search);

            HDDHecmIndexViewModel HDDHecmIndexVM = new HDDHecmIndexViewModel
            {
                PagenatedItems = PagenetedList<HDDHecm>.Create(HDDHecms, page, 8),
            };

            return View(HDDHecmIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HDDHecmCreateDto createDto)
        {
            try
            {
                await _HDDHecmCreateServices.CreateGB(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "HDDHecm");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _HDDHecmEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _HDDHecmEditServices.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HDDHecmEditDto HDDHecmEdit)
        {
            try
            {
                await _HDDHecmEditServices.HDDHecmEdit(HDDHecmEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(HDDHecmEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "HDDHecm");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _HDDHecmDeleteServices.HDDHecmDelete(id);
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
