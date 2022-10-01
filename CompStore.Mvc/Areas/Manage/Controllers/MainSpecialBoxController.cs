using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.MainSpecialBoxs;
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

    public class MainSpecialBoxController : Controller
    {
        private readonly DataContext _context;
        private readonly IMainSpecialBoxIndexServices _MainSpecialBoxIndexServices;
        private readonly IMainSpecialBoxCreateServices _MainSpecialBoxCreate;
        private readonly IMainSpecialBoxDeleteServices _MainSpecialBoxDelete;
        private readonly IMainSpecialBoxEditServices _MainSpecialBoxEdit;

        public MainSpecialBoxController(DataContext context, IMainSpecialBoxIndexServices MainSpecialBoxIndexServices, IMainSpecialBoxCreateServices MainSpecialBoxCreate, IMainSpecialBoxDeleteServices MainSpecialBoxDelete, IMainSpecialBoxEditServices MainSpecialBoxEdit)
        {
            _context = context;
            _MainSpecialBoxIndexServices = MainSpecialBoxIndexServices;
            _MainSpecialBoxCreate = MainSpecialBoxCreate;
            _MainSpecialBoxDelete = MainSpecialBoxDelete;
            _MainSpecialBoxEdit = MainSpecialBoxEdit;
        }

        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var MainSpecialBoxs = await _MainSpecialBoxIndexServices.SearchCheck(search);

            MainSpecialBoxIndexViewModel MainSpecialBoxIndexVM = new MainSpecialBoxIndexViewModel
            {
                PagenatedItems = PagenetedList<MainSpecialBox>.Create(MainSpecialBoxs, page, 6),
            };

            return View(MainSpecialBoxIndexVM);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MainSpecialBoxCreateDto createDto)
        {
            try
            {
                await _MainSpecialBoxCreate.CreateMainSpecialBox(createDto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "MainSpecialBox");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _MainSpecialBoxEdit.IsExists(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _MainSpecialBoxEdit.IsExists(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MainSpecialBoxEditDto MainSpecialBoxEdit)
        {
            try
            {
                await _MainSpecialBoxEdit.MainSpecialBoxEdit(MainSpecialBoxEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(MainSpecialBoxEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "MainSpecialBox");
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _MainSpecialBoxDelete.MainSpecialBoxDelete(id);
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233088)
                {
                    TempData["Error"] = ("MainSpecialBox məhsulda istifade olunur deye silmek mümkün olmadı!");
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
