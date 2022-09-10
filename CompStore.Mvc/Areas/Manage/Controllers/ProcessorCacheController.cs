using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.ProcessorCaches;
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
    public class ProcessorCacheController : Controller
    {
        private readonly DataContext _context;
        private readonly IProcessorCacheCreateServices _ProcessorCacheCreateServices;
        private readonly IProcessorCacheDeleteServices _ProcessorCacheDeleteServices;
        private readonly IProcessorCacheEditServices _ProcessorCacheEditServices;
        private readonly IProcessorCacheIndexServices _ProcessorCacheIndexServices;

        public ProcessorCacheController(DataContext context, IProcessorCacheCreateServices ProcessorCacheCreateServices, IProcessorCacheDeleteServices ProcessorCacheDeleteServices, IProcessorCacheEditServices ProcessorCacheEditServices, IProcessorCacheIndexServices ProcessorCacheIndexServices)
        {
            _context = context;
            _ProcessorCacheCreateServices = ProcessorCacheCreateServices;
            _ProcessorCacheDeleteServices = ProcessorCacheDeleteServices;
            _ProcessorCacheEditServices = ProcessorCacheEditServices;
            _ProcessorCacheIndexServices = ProcessorCacheIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var ProcessorCaches = await _ProcessorCacheIndexServices.SearchCheck(search);

            ProcessorCacheIndexViewModel ProcessorCacheIndexVM = new ProcessorCacheIndexViewModel
            {
                PagenatedItems = PagenetedList<ProcessorCache>.Create(ProcessorCaches, page, 6),
            };

            return View(ProcessorCacheIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProcessorCacheCreateDto createDto)
        {
            try
            {
                await _ProcessorCacheCreateServices.CreateCache(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "ProcessorCache");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _ProcessorCacheEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _ProcessorCacheEditServices.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProcessorCacheEditDto ProcessorCacheEdit)
        {
            try
            {
                await _ProcessorCacheEditServices.ProcessorCacheEdit(ProcessorCacheEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(ProcessorCacheEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "ProcessorCache");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ProcessorCacheDeleteServices.ProcessorCacheDelete(id);
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
