using CompStore.Core.Entites;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Helper;
using CompStore.Service.Services.Interfaces.Area;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Areas.Manage.Controllers
{

    public class ContactUsController : Controller
    {
        private readonly IContactUsIndexServices _ContactUsIndexServices;
        private readonly IContactUsDeleteServices _ContactUsDelete;

        public ContactUsController(IContactUsIndexServices ContactUsIndexServices, IContactUsDeleteServices ContactUsDelete)
        {
            _ContactUsIndexServices = ContactUsIndexServices;
            _ContactUsDelete = ContactUsDelete;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            ViewBag.Page = page;

            var ContactUss = await _ContactUsIndexServices.SearchCheck(search);

            ContactUsIndexViewModel ContactUsIndexVM = new ContactUsIndexViewModel
            {
                PagenatedItems = PagenetedList<ContactUs>.Create(ContactUss, page, 6),
            };

            return View(ContactUsIndexVM);
        }

        // GET: Manage/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ContactUsDelete.ContactUsDelete(id);
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233088)
                {
                    TempData["Error"] = ("ContactUs məhsulda istifade olunur deye silmek mümkün olmadı!");
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
