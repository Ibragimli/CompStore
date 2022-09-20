using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.Videokarts;
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
    public class VideokartController : Controller
    {
        private readonly DataContext _context;
        private readonly IVideokartCreateServices _VideokartCreateServices;
        private readonly IVideokartDeleteServices _VideokartDeleteServices;
        private readonly IVideokartEditServices _VideokartEditServices;
        private readonly IVideokartIndexServices _VideokartIndexServices;

        public VideokartController(DataContext context, IVideokartCreateServices VideokartCreateServices, IVideokartDeleteServices VideokartDeleteServices, IVideokartEditServices VideokartEditServices, IVideokartIndexServices VideokartIndexServices)
        {
            _context = context;
            _VideokartCreateServices = VideokartCreateServices;
            _VideokartDeleteServices = VideokartDeleteServices;
            _VideokartEditServices = VideokartEditServices;
            _VideokartIndexServices = VideokartIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var Videokarts = await _VideokartIndexServices.SearchCheck(search);

            VideokartIndexViewModel VideokartIndexVM = new VideokartIndexViewModel
            {
                PagenatedItems = PagenetedList<Videokart>.Create(Videokarts, page, 6),
            };

            return View(VideokartIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VideokartCreateDto createDto)
        {
            try
            {
                await _VideokartCreateServices.CreateVideokart(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "Videokart");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _VideokartEditServices.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _VideokartEditServices.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VideokartEditDto VideokartEdit)
        {
            try
            {
                await _VideokartEditServices.VideokartEdit(VideokartEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(VideokartEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "Videokart");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _VideokartDeleteServices.VideokartDelete(id);
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
