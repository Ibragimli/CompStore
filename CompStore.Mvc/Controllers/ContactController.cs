using CompStore.Core.Entites;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.User;
using CompStore.Service.Services.Interfaces.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactUsServices _contactUsServices;

        public ContactController(IContactUsServices contactUsServices)
        {
            _contactUsServices = contactUsServices;
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> ContactUs(ContactUsPostDto contactUsPostDto)
        {
            try
            {
                await _contactUsServices.CreateContactUs(contactUsPostDto);

            }
            catch (ItemNotFoundException ex)
            {
                TempData["Error"] = ex.Message;
                return View();

            }

            catch (Exception)
            {
                return View();
            }
            TempData["Success"] = "Sorğunuz göndərildi";
            return RedirectToAction("contactus", "contact");
        }
    }
}
