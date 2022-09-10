using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.ProcessorModels;
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
    public class ProcessorModelController : Controller
    {
        private readonly DataContext _context;
        private readonly IProcessorModelCreateServices _ProcessorModelCreateServices;
        private readonly IProcessorModelDeleteServices _ProcessorModelDeleteServices;
        private readonly IProcessorModelEditServices _ProcessorModelEditServices;
        private readonly IProcessorModelIndexServices _ProcessorModelIndexServices;

        public ProcessorModelController(DataContext context, IProcessorModelCreateServices ProcessorModelCreateServices, IProcessorModelDeleteServices ProcessorModelDeleteServices, IProcessorModelEditServices ProcessorModelEditServices, IProcessorModelIndexServices ProcessorModelIndexServices)
        {
            _context = context;
            _ProcessorModelCreateServices = ProcessorModelCreateServices;
            _ProcessorModelDeleteServices = ProcessorModelDeleteServices;
            _ProcessorModelEditServices = ProcessorModelEditServices;
            _ProcessorModelIndexServices = ProcessorModelIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var ProcessorModels = await _ProcessorModelIndexServices.SearchCheck(search);

            ProcessorModelIndexViewModel ProcessorModelIndexVM = new ProcessorModelIndexViewModel
            {
                PagenatedItems = PagenetedList<ProcessorModel>.Create(ProcessorModels, page, 6),
            };

            return View(ProcessorModelIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProcessorModelCreateDto createDto)
        {
            try
            {
                await _ProcessorModelCreateServices.CreateModel(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "ProcessorModel");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _ProcessorModelEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _ProcessorModelEditServices.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProcessorModelEditDto ProcessorModelEdit)
        {
            try
            {
                await _ProcessorModelEditServices.ProcessorModelEdit(ProcessorModelEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(ProcessorModelEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "ProcessorModel");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ProcessorModelDeleteServices.ProcessorModelDelete(id);
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