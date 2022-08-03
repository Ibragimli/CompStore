using CompStore.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.HelperService.Interfaces
{
    public interface IImageValue
    {
        public string ValueStr(string key);
        public int ValueInt(string key);

    }
}
