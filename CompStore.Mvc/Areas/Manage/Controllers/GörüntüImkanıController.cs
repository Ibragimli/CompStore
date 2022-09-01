using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.GörüntüImkanıs;
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
    public class GörüntüImkanıController : Controller
    {
        private readonly DataContext _context;
        private readonly IGörüntüImkanıCreateServices _GörüntüImkanıCreateServices;
        private readonly IGörüntüImkanıDeleteServices _GörüntüImkanıDeleteServices;
        private readonly IGörüntüImkanıEditServices _GörüntüImkanıEditServices;
        private readonly IGörüntüImkanıIndexServices _GörüntüImkanıIndexServices;

        public GörüntüImkanıController(DataContext context, IGörüntüImkanıCreateServices GörüntüImkanıCreateServices, IGörüntüImkanıDeleteServices GörüntüImkanıDeleteServices, IGörüntüImkanıEditServices GörüntüImkanıEditServices, IGörüntüImkanıIndexServices GörüntüImkanıIndexServices)
        {
            _context = context;
            _GörüntüImkanıCreateServices = GörüntüImkanıCreateServices;
            _GörüntüImkanıDeleteServices = GörüntüImkanıDeleteServices;
            _GörüntüImkanıEditServices = GörüntüImkanıEditServices;
            _GörüntüImkanıIndexServices = GörüntüImkanıIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var GörüntüImkanıs = await _GörüntüImkanıIndexServices.SearchCheck(search);

            GörüntüImkanıIndexViewModel GörüntüImkanıIndexVM = new GörüntüImkanıIndexViewModel
            {
                PagenatedItems = PagenetedList<GörüntüImkanı>.Create(GörüntüImkanıs, page, 2),
            };

            return View(GörüntüImkanıIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GörüntüImkanıCreateDto createDto)
        {
            try
            {
                await _GörüntüImkanıCreateServices.CreateGB(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "GörüntüImkanı");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _GörüntüImkanıEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _GörüntüImkanıEditServices.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GörüntüImkanıEditDto GörüntüImkanıEdit)
        {
            try
            {
                await _GörüntüImkanıEditServices.GörüntüImkanıEdit(GörüntüImkanıEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(GörüntüImkanıEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "GörüntüImkanı");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _GörüntüImkanıDeleteServices.GörüntüImkanıDelete(id);
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
