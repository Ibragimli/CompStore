using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.HelperService.Interfaces
{
    public interface IManageImageHelper
    {
        public void PosterCheck(Product Image);
        public void ImagesCheck(Product Images);
        public string FileSave(Product Image);
        public void DeleteFile(string image);
    }
}
