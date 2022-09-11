using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.Settings;
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
    public class SettingController : Controller
    {
        private readonly DataContext _context;
        private readonly ISettingEditServices _SettingEditServices;
        private readonly ISettingIndexServices _SettingIndexServices;

        public SettingController(DataContext context, ISettingEditServices SettingEditServices, ISettingIndexServices SettingIndexServices)
        {
            _context = context;
            _SettingEditServices = SettingEditServices;
            _SettingIndexServices = SettingIndexServices;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var Settings = await _SettingIndexServices.SearchCheck(search);

            SettingIndexViewModel SettingIndexVM = new SettingIndexViewModel
            {
                PagenatedItems = PagenetedList<Setting>.Create(Settings, page, 6),
            };

            return View(SettingIndexVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                await _SettingEditServices.IsExists(id);
                await _SettingEditServices.GetSearch(id);
            }
            catch (Exception)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(await _SettingEditServices.GetSearch(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SettingEditDto SettingEdit)
        {
            try
            {
                await _SettingEditServices.SettingEdit(SettingEdit);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(SettingEdit);
            }
            TempData["Success"] = ("Proses uğurlu oldu!");
            return RedirectToAction("index", "Setting");
        }


    }
}
