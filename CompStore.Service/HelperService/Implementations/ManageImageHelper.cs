using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Helper;
using CompStore.Service.HelperService.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompStore.Service.HelperService.Implementations
{
    public class ManageImageHelper : IManageImageHelper
    {
        private readonly IWebHostEnvironment _env;

        
        public ManageImageHelper( IWebHostEnvironment env)
        {
            _env = env;
        }
        public void PosterCheck(Product Image)
        {
            if (Image.PosterImageFile.ContentType != "image/png" && Image.PosterImageFile.ContentType != "image/jpeg")
                throw new ImageFormatException("Poster şekli yalnız (png ve ya jpg) type-ında ola biler");

            if (Image.PosterImageFile.Length > 2097152)
                throw new ImageFormatException("Poster şeklinin max yaddaşı 2MB ola biler!");
        }
        public void ImagesCheck(Product Images)
        {
            foreach (var image in Images.ImageFiles)
            {
                if (image.ContentType != "image/png" && image.ContentType != "image/jpeg")
                    throw new ImageFormatException("Poster şekli yalnız (png ve ya jpg) type-ında ola biler");
                if (image.Length > 2097152)
                    throw new ImageFormatException("Poster şeklinin max yaddaşı 2MB ola biler!");
            }
        }
        public string FileSave(Product Image)
        {
            string image = FileManager.Save(_env.WebRootPath, "uploads/product", Image.PosterImageFile);
            return image; ;
        }
        public void DeleteFile(string image)
        {
            FileManager.Delete(_env.WebRootPath, "uploads/product", image);
        }
    }
}
