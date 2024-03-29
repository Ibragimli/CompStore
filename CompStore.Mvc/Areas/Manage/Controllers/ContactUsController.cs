﻿using CompStore.Core.Entites;
using CompStore.Mvc.Areas.Manage.ViewModels;
using CompStore.Service.Dtos.Area.ContactUs;
using CompStore.Service.Helper;
using CompStore.Service.Services.Interfaces;
using CompStore.Service.Services.Interfaces.Area;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ContactUsController : Controller
    {
        private readonly IEmailServices _emailServices;
        private readonly IContactUsIndexServices _ContactUsIndexServices;
        private readonly IContactUsDeleteServices _ContactUsDelete;
        private readonly IContactRespondServices _СontactRespondServices;
        public ContactUsController(IEmailServices emailServices, IContactUsIndexServices ContactUsIndexServices, IContactUsDeleteServices ContactUsDelete, IContactRespondServices ContactRespondServices)
        {
            _emailServices = emailServices;
            _ContactUsIndexServices = ContactUsIndexServices;
            _ContactUsDelete = ContactUsDelete;
            _СontactRespondServices = ContactRespondServices;
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

        public async Task<IActionResult> ReplyContactUs(int contactUsId)
        {
            ContactUsReplyViewDto contactUs;
            try
            {
                contactUs = await _СontactRespondServices.RespondView(contactUsId);
            }
            catch (Exception ex)
            {

                contactUs = await _СontactRespondServices.RespondView(contactUsId);
                ModelState.AddModelError("ReplyText", ex.Message);
                return View(contactUs);
            }
            return View(contactUs);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> ReplyContactUs(int contactUsId, ReplyContactPostDto replyContactPostDto)
        {
            ContactUsReplyViewDto contactUs;
            ReplyContactPostDto contactUsPost;
            try
            {
                contactUsPost = await _СontactRespondServices.RespondAnswer(contactUsId, replyContactPostDto.ReplyText);
                contactUs = await _СontactRespondServices.RespondView(contactUsId);
            }
            catch (Exception ex)
            {

                contactUs = await _СontactRespondServices.RespondView(contactUsId);
                ModelState.AddModelError("ReplyText", ex.Message);
                return View(contactUs);
            }
            string body = string.Empty;

            using (StreamReader reader = new StreamReader("wwwroot/templates/contactEmail.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{{fullname}}", contactUs.Fullname);
            body = body.Replace("{{replyText}}", replyContactPostDto.ReplyText);
            _emailServices.Send(contactUsPost.Email, "no-reply", body);
            TempData["Success"] = "Mesaj göndəərildi";

            return RedirectToAction("index", "contactus");
        }
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
