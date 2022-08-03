using CompStore.Core.Entites;
using CompStore.Data;
using CompStore.Service.HelperService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompStore.Service.HelperService.Implementations
{
    public class ImageValue : IImageValue
    {
        private readonly DataContext _context;

        public ImageValue(DataContext context)
        {
            _context = context;
        }
        public string ValueStr(string key)
        {
            var value = _context.ImageSettings.Where(x => !x.IsDelete).FirstOrDefault(x => x.Key == key).Value;
            return value;
        }
        public int ValueInt(string key)
        {
            var valueStr = _context.ImageSettings.Where(x => !x.IsDelete).FirstOrDefault(x => x.Key == key).Value;
            int value = int.Parse(valueStr);
            return value;
        }
    }
}
