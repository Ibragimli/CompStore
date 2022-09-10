using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.ProcessorGhzs;
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
    public class ProcessorGhzController : Controller
    {
        private readonly DataContext _context;
        private readonly IProcessorGhzCreateServices _ProcessorGhzCreateServices;
        private readonly IProcessorGhzDeleteServices _ProcessorGhzDeleteServices;
        private readonly IProcessorGhzEditServices _ProcessorGhzEditServices;
        private readonly IProcessorGhzIndexServices _ProcessorGhzIndexServices;

        public ProcessorGhzController(DataContext context, IProcessorGhzCreateServices ProcessorGhzCreateServices, IProcessorGhzDeleteServices ProcessorGhzDeleteServices, IProcessorGhzEditServices ProcessorGhzEditServices, IProcessorGhzIndexServices ProcessorGhzIndexServices)
        {
            _context = context;
            _ProcessorGhzCreateServices = ProcessorGhzCreateServices;
            _ProcessorGhzDeleteServices = ProcessorGhzDeleteServices;
            _ProcessorGhzEditServices = ProcessorGhzEditServices;
            _ProcessorGhzIndexServices = ProcessorGhzIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var ProcessorGhzs = await _ProcessorGhzIndexServices.SearchCheck(search);

            ProcessorGhzIndexViewModel ProcessorGhzIndexVM = new ProcessorGhzIndexViewModel
            {
                PagenatedItems = PagenetedList<ProcessorGhz>.Create(ProcessorGhzs, page, 6),
            };

            return View(ProcessorGhzIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProcessorGhzCreateDto createDto)
        {
            try
            {
                await _ProcessorGhzCreateServices.CreateGhz(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "ProcessorGhz");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _ProcessorGhzEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _ProcessorGhzEditServices.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProcessorGhzEditDto ProcessorGhzEdit)
        {
            try
            {
                await _ProcessorGhzEditServices.ProcessorGhzEdit(ProcessorGhzEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(ProcessorGhzEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "ProcessorGhz");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ProcessorGhzDeleteServices.ProcessorGhzDelete(id);
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
