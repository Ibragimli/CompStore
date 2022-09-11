using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.HelperService.Interfaces
{
    public interface ISettingImageHelper
    {
        public void CheckImage(Setting Image);
        public void ImagesCheck(Setting Image);
        public string FileSave(Setting Image);
        public void DeleteFile(string image);
    }
}
