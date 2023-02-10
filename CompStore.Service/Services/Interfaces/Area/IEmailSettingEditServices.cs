using CompStore.Core.Entites;
using CompStore.Service.Dtos.Area.EmailSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IEmailSettingEditServices
    {
        public void EditEmailSetting(EmaiLSettingEditDto emailSetting);
        Task<EmaiLSettingEditDto> IsExists(int id);
        Task<IQueryable<EmailSetting>> SearchCheck(int id);


    }
}
