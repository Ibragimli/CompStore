using CompStore.Core.Entites;
using CompStore.Service.CustomExceptions;
using CompStore.Service.Helper;
using CompStore.Service.HelperService.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.HelperService.Implementations
{
    public class SettingImageHelper : ISettingImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly IImageValue _key;



        public SettingImageHelper(IWebHostEnvironment env, IImageValue key)
        {
            _env = env;
            _key = key;
        }
        public void CheckImage(Setting Image)
        {

            if (Image.KeyImageFile.ContentType != _key.ValueStr("ImageType1") && Image.KeyImageFile.ContentType != _key.ValueStr("ImageType2"))
                throw new ImageFormatException("Poster şekli yalnız (png ve ya jpg) type-ında ola biler");

            if (Image.KeyImageFile.Length > _key.ValueInt("ImageSize") * 1048576)
                throw new ImageFormatException("Poster şeklinin max yaddaşı 2MB ola biler!");

        }
        public void ImagesCheck(Setting Images)
        {
            
            //foreach (var image in Images.KeyImagesFiles)
            //{
            //    if (image.ContentType != _key.ValueStr("ImageType1") && image.ContentType != _key.ValueStr("ImageType2"))
            //        throw new ImageFormatException("Poster şekli yalnız (png ve ya jpg) type-ında ola biler");
            //    if (image.Length > _key.ValueInt("ImageSize") * 1048576)
            //        throw new ImageFormatException("Poster şeklinin max yaddaşı 2MB ola biler!");
            //}
        }

        public string FileSave(Setting Image)
        {
            string image = FileManager.Save(_env.WebRootPath, "uploads/settings", Image.KeyImageFile);
            return image; ;
        }

        public void DeleteFile(string image)
        {
            FileManager.Delete(_env.WebRootPath, "uploads/settings", image);
        }


    }
}
