using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.VideokartRams;
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
    public class VideokartRamController : Controller
    {
        private readonly DataContext _context;
        private readonly IVideokartRamCreateServices _VideokartRamCreateServices;
        private readonly IVideokartRamDeleteServices _VideokartRamDeleteServices;
        private readonly IVideokartRamEditServices _VideokartRamEditServices;
        private readonly IVideokartRamIndexServices _VideokartRamIndexServices;

        public VideokartRamController(DataContext context, IVideokartRamCreateServices VideokartRamCreateServices, IVideokartRamDeleteServices VideokartRamDeleteServices, IVideokartRamEditServices VideokartRamEditServices, IVideokartRamIndexServices VideokartRamIndexServices)
        {
            _context = context;
            _VideokartRamCreateServices = VideokartRamCreateServices;
            _VideokartRamDeleteServices = VideokartRamDeleteServices;
            _VideokartRamEditServices = VideokartRamEditServices;
            _VideokartRamIndexServices = VideokartRamIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var VideokartRams = await _VideokartRamIndexServices.SearchCheck(search);

            VideokartRamIndexViewModel VideokartRamIndexVM = new VideokartRamIndexViewModel
            {
                PagenatedItems = PagenetedList<VideokartRam>.Create(VideokartRams, page, 2),
            };
            

            return View(VideokartRamIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VideokartRamCreateDto createDto)
        {
            try
            {
                await _VideokartRamCreateServices.CreateRam(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "VideokartRam");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _VideokartRamEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _VideokartRamEditServices.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VideokartRamEditDto VideokartRamEdit)
        {
            try
            {
                await _VideokartRamEditServices.VideokartRamEdit(VideokartRamEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(VideokartRamEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "VideokartRam");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _VideokartRamDeleteServices.VideokartRamDelete(id);
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
