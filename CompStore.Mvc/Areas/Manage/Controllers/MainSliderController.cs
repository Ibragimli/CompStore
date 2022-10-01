using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.MainSliders;
using CompStore.Service.Helper;
using CompStore.Service.Services.Interfaces.Area;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Areas.Manage.Controllers
{

    [Area("manage")]
    public class MainSliderController : Controller
    {
        private readonly DataContext _context;
        private readonly IMainSliderIndexServices _MainSliderIndexServices;
        private readonly IMainSliderCreateServices _MainSliderCreate;
        private readonly IMainSliderDeleteServices _MainSliderDelete;
        private readonly IMainSliderEditServices _MainSliderEdit;

        public MainSliderController(DataContext context, IMainSliderIndexServices MainSliderIndexServices, IMainSliderCreateServices MainSliderCreate, IMainSliderDeleteServices MainSliderDelete, IMainSliderEditServices MainSliderEdit)
        {
            _context = context;
            _MainSliderIndexServices = MainSliderIndexServices;
            _MainSliderCreate = MainSliderCreate;
            _MainSliderDelete = MainSliderDelete;
            _MainSliderEdit = MainSliderEdit;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var MainSliders = await _MainSliderIndexServices.SearchCheck(search);

            MainSliderIndexViewModel MainSliderIndexVM = new MainSliderIndexViewModel
            {
                PagenatedItems = PagenetedList<MainSlider>.Create(MainSliders, page, 6),
            };

            return View(MainSliderIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MainSliderCreateDto createDto)
        {
            try
            {
                await _MainSliderCreate.CreateMainSlider(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "MainSlider");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _MainSliderEdit.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _MainSliderEdit.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MainSliderEditDto MainSliderEdit)
        {
            try
            {
                await _MainSliderEdit.MainSliderEdit(MainSliderEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(MainSliderEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "MainSlider");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _MainSliderDelete.MainSliderDelete(id);
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233088)
                {
                    TempData["Error"] = ("MainSlider məhsulda istifade olunur deye silmek mümkün olmadı!");
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
