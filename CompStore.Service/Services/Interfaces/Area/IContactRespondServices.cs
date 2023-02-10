using CompStore.Service.Dtos.Area.ContactUs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IContactRespondServices
    {
        public Task<ContactUsReplyViewDto> RespondView(int contactUsId);
        public Task<ReplyContactPostDto> RespondAnswer(int contactUsId, string RespondText);
    }
}
