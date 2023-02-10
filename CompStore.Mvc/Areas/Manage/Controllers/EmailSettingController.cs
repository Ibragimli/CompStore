using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.EmailSettings;
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
    public class EmailSettingController : Controller
    {
        private readonly IEmailSettingEditServices _emailSettingEdit;

        public EmailSettingController(IEmailSettingEditServices EmailSettingEditServices)
        {
            _emailSettingEdit = EmailSettingEditServices;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            
            ViewBag.Page = page;

            var emailSettings = await _emailSettingEdit.SearchCheck(1);

            EmailSettingIndexViewModel ColorIndexVM = new EmailSettingIndexViewModel
            {
                PagenatedItems = PagenetedList<EmailSetting>.Create(emailSettings, page, 6),
            };

            return View(ColorIndexVM);
        }

        //public async Task<IActionResult> Index(int id)
        //{
        //    try
        //    {
        //        await _emailSettingEdit.IsExists(id);
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction("notfound", "error");
        //    }

        //    var emailsetting = await _emailSettingEdit.IsExists(id);
        //    return View(emailsetting);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Index(EmaiLSettingEditDto EmailSettingEdit)
        //{
        //    try
        //    {
        //        _emailSettingEdit.EditEmailSetting(EmailSettingEdit);
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //        return View(await _emailSettingEdit.IsExists(EmailSettingEdit.EmailSetting.Id));
        //    }
        //    TempData["Success"] = ("Proses uğurlu oldu!");
        //    return RedirectToAction("index", "EmailSetting");
        //}
    }
}
