using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.EmailSettings;
using CompStore.Service.Services.Interfaces.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Implementations.Area
{
    public class EmailSettingEditServices : IEmailSettingEditServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmailSettingEditServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async void EditEmailSetting(EmaiLSettingEditDto emailSetting)
        {
            var isEmail = await _unitOfWork.EmailSettingRepository.GetAsync(x => x.Id == emailSetting.EmailSetting.Id);
            if (isEmail == null) throw new ItemNotFoundException("Xəta baş verdi");

            isEmail.SmtpEmail = emailSetting.EmailSetting.SmtpEmail;
            isEmail.SmtpHost = emailSetting.EmailSetting.SmtpHost;
            isEmail.SmtpPort = emailSetting.EmailSetting.SmtpPort;
            isEmail.SmtpPassword = emailSetting.EmailSetting.SmtpPassword;

            await _unitOfWork.CommitAsync();
        }
        public async Task<IQueryable<EmailSetting>> SearchCheck(int id)
        {
            var ColorLast = _unitOfWork.EmailSettingRepository.asQueryable();
            var emailsetting = _unitOfWork.EmailSettingRepository;


            //categorySearch
            bool nameSearch = await emailsetting.IsExistAsync(x => x.Id == id);

            return ColorLast;
        }

        public async Task<EmaiLSettingEditDto> IsExists(int id)
        {
            var emailSettingExist = await _unitOfWork.EmailSettingRepository.GetAsync(x => x.Id == id);
            if (emailSettingExist == null)
                throw new Exception("ERROR");
            EmaiLSettingEditDto editDto = new EmaiLSettingEditDto
            {
                EmailSetting = emailSettingExist,
            };
            return editDto;
        }
    }
}
