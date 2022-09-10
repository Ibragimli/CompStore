using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos;
using CompStore.Service.Dtos.Area.RamDDRs;
using CompStore.Service.Helper;
using CompStore.Service.Services.Implementations;
using CompStore.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Areas.Manage.Controllers
{
    [Area("manage")]
    public class RamDDRController : Controller
    {
        private readonly DataContext _context;
        private readonly IRamDDRIndexServices _ramDDRIndexServices;
        private readonly IRamDDRCreateServices _ramDDRCreateServices;
        private readonly IRamDDRDeleteServices _ramDDRDeleteServices;
        private readonly IRamDDREditServices _ramDDREditServices;

        public RamDDRController(DataContext context, IRamDDRIndexServices ramDDRIndexServices, IRamDDRCreateServices ramDDRCreateServices, IRamDDRDeleteServices ramDDRDeleteServices, IRamDDREditServices ramDDREditServices)
        {
            _context = context;
            _ramDDRIndexServices = ramDDRIndexServices;
            _ramDDRCreateServices = ramDDRCreateServices;
            _ramDDRDeleteServices = ramDDRDeleteServices;
            _ramDDREditServices = ramDDREditServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var RamDDRs = await _ramDDRIndexServices.SearchCheck(search);

            RamDDRIndexViewModel RamDDRIndexVM = new RamDDRIndexViewModel
            {
                PagenatedItems = PagenetedList<RamDDR>.Create(RamDDRs, page, 6),
            };

            return View(RamDDRIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RamDDRCreateDto createDto)
        {
            try
            {
                await _ramDDRCreateServices.CreateDDR(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "RamDDR");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _ramDDREditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _ramDDREditServices.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RamDDREditDto RamDDREdit)
        {
            try
            {
                await _ramDDREditServices.RamDDREdit(RamDDREdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(RamDDREdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "RamDDR");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ramDDRDeleteServices.RamDDRDelete(id);
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
