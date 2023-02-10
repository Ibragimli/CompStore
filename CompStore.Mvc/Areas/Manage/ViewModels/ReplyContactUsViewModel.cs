using CompStore.Service.Dtos.Area.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Areas.Manage.ViewModels
{
    public class ReplyContactUsViewModel
    {
        public int ContactUsId { get; set; }
        public string ReplyText { get; set; }
        public string Fullname { get; set; }
        public ReplyContactPostDto ReplyContactPostDto { get; set; }
    }

}
