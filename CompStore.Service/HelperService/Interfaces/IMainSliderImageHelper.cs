using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.HelperService.Interfaces
{
    public interface IMainSliderImageHelper
    {
        public void ImageCheck(MainSlider Images);
        public string FileSave(MainSlider Image);
        public void DeleteFile(string image);
    }
}
