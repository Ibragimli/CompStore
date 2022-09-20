using CompStore.Core.Repositories;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Dtos.Area.Settings;
using CompStore.Service.Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CompStore.Core.Entites;
using CompStore.Service.HelperService.Interfaces;
using Microsoft.AspNetCore.Hosting;
using CompStore.Service.Services.Interfaces.Area;

namespace CompStore.Service.Services.Implementations.Area
{
    public class SettingEditServices : ISettingEditServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISettingImageHelper _settingImage;
        private readonly IWebHostEnvironment _env;

        public SettingEditServices(IUnitOfWork unitOfWork, ISettingImageHelper settingImage, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _settingImage = settingImage;
            _env = env;
        }


        public async Task<SettingEditDto> GetSearch(int Id)
        {
            var setting = await _unitOfWork.SettingRepository.GetAsync(x => x.Id == Id);
            if (setting == null)
                throw new ItemNotFoundException("Setting tapılmadı");


            SettingEditDto settingEditDto = new SettingEditDto
            {
                Id = setting.Id,
                Key = setting.Key,
                KeyImageFile = setting.KeyImageFile,
                Value = setting.Value,
            };
            return settingEditDto;
        }

        public async Task SettingEdit(SettingEditDto SettingEdit)
        {
            if (SettingEdit.Value == null)
                throw new ItemNotFoundException("Value adı boş ola bilməz!");


            var lastSetting = await _unitOfWork.SettingRepository.GetAsync(x => x.Id == SettingEdit.Id);

            if (lastSetting == null)
                throw new ItemNotFoundException("Setting tapilmadı!");
            if (lastSetting.Value != SettingEdit.Value)
            {
                if (SettingEdit.Value != null)
                    lastSetting.Value = SettingEdit.Value;

                if (SettingEdit.KeyImageFile != null)
                {
                    lastSetting.KeyImageFile = SettingEdit.KeyImageFile;

                    _settingImage.ImagesCheck(lastSetting);

                    _settingImage.DeleteFile(lastSetting.Value);

                    lastSetting.Value = _settingImage.FileSave(lastSetting);
                    lastSetting.ModifiedDate = DateTime.UtcNow.AddHours(4);

                }
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<SettingEditDto> IsExists(int id)
        {
            var SettingExist = await _unitOfWork.SettingRepository.GetAsync(x => x.Id == id);
            if (SettingExist == null)
                throw new Exception("ERROR");
            SettingEditDto editDto = new SettingEditDto
            {
                Value = SettingExist.Value,
                Id = SettingExist.Id,
            };
            return editDto;
        }


    }
}
