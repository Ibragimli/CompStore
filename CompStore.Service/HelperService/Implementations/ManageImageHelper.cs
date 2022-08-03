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
        private readonly IImageValue _key;

        public ManageImageHelper(IWebHostEnvironment env, IImageValue key)
        {
            _env = env;
            _key = key;
        }
        public void PosterCheck(Product Image)
        {
            if (Image.PosterImageFile.ContentType != _key.ValueStr("ImageType1") && Image.PosterImageFile.ContentType != _key.ValueStr("ImageType2"))
                throw new ImageFormatException("Poster şekli yalnız (png ve ya jpg) type-ında ola biler");

            if (Image.PosterImageFile.Length > _key.ValueInt("ImageSize") * 1048576)
                throw new ImageFormatException("Poster şeklinin max yaddaşı 2MB ola biler!");
        }
        public void ImagesCheck(Product Images)
        {
            foreach (var image in Images.ImageFiles)
            {
                if (image.ContentType != _key.ValueStr("ImageType1") && image.ContentType != _key.ValueStr("ImageType2"))
                    throw new ImageFormatException("Poster şekli yalnız (png ve ya jpg) type-ında ola biler");
                if (image.Length > _key.ValueInt("ImageSize") * 1048576)
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
