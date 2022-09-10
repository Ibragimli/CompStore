using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.OperationSystems;
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
    public class OperationSystemController : Controller
    {
        private readonly DataContext _context;
        private readonly IOperationSystemCreateServices _OperationSystemCreateServices;
        private readonly IOperationSystemDeleteServices _OperationSystemDeleteServices;
        private readonly IOperationSystemEditServices _OperationSystemEditServices;
        private readonly IOperationSystemIndexServices _OperationSystemIndexServices;

        public OperationSystemController(DataContext context, IOperationSystemCreateServices OperationSystemCreateServices, IOperationSystemDeleteServices OperationSystemDeleteServices, IOperationSystemEditServices OperationSystemEditServices, IOperationSystemIndexServices OperationSystemIndexServices)
        {
            _context = context;
            _OperationSystemCreateServices = OperationSystemCreateServices;
            _OperationSystemDeleteServices = OperationSystemDeleteServices;
            _OperationSystemEditServices = OperationSystemEditServices;
            _OperationSystemIndexServices = OperationSystemIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var OperationSystems = await _OperationSystemIndexServices.SearchCheck(search);

            OperationSystemIndexViewModel OperationSystemIndexVM = new OperationSystemIndexViewModel
            {
                PagenatedItems = PagenetedList<OperationSystem>.Create(OperationSystems, page, 6),
            };

            return View(OperationSystemIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OperationSystemCreateDto createDto)
        {
            try
            {
                await _OperationSystemCreateServices.CreateSystem(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "OperationSystem");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _OperationSystemEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _OperationSystemEditServices.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OperationSystemEditDto OperationSystemEdit)
        {
            try
            {
                await _OperationSystemEditServices.OperationSystemEdit(OperationSystemEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(OperationSystemEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "OperationSystem");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _OperationSystemDeleteServices.OperationSystemDelete(id);
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
