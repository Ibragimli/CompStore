using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.HelperService.Interfaces
{
    public interface IBrandImageHelper
    {
        public void ImageCheck(Brand Images);
        public string FileSave(Brand Image);
        public void DeleteFile(string image);
    }
}
