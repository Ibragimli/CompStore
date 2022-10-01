using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.HelperService.Interfaces
{
    public interface IMainSpecialBoxImageHelper
    {
        public void ImageCheck(MainSpecialBox Image);
        public string FileSave(MainSpecialBox Image);
        public void DeleteFile(string image);
    }
}
