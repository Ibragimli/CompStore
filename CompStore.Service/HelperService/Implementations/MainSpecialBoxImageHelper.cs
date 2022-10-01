using CompStore.Core.Entites;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Helper;
using CompStore.Service.HelperService.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.HelperService.Implementations
{

    public class MainSpecialBoxImageHelper : IMainSpecialBoxImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly IImageValue _key;

        public MainSpecialBoxImageHelper(IWebHostEnvironment env, IImageValue key)
        {
            _env = env;
            _key = key;
        }


        public void DeleteFile(string image)
        {
            FileManager.Delete(_env.WebRootPath, "uploads/MainSpecialBoxs", image);
        }

        public void ImageCheck(MainSpecialBox Image)
        {
            if (Image.ImageFile.ContentType != _key.ValueStr("ImageType1") && Image.ImageFile.ContentType != _key.ValueStr("ImageType2"))
                throw new ImageFormatException("Poster şekli yalnız (png ve ya jpg) type-ında ola biler");
            if (Image.ImageFile.Length > _key.ValueInt("ImageSize") * 1048576)
                throw new ImageFormatException("Poster şeklinin max yaddaşı 2MB ola biler!");
        }

        public string FileSave(MainSpecialBox Image)
        {
            string image = FileManager.Save(_env.WebRootPath, "uploads/MainSpecialBoxs", Image.ImageFile);
            return image; ;
        }
    }
}
