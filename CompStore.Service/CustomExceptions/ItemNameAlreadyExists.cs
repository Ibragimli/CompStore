using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.CustomExceptions
{
    public class ItemNameAlreadyExists : Exception
    {
        public ItemNameAlreadyExists(string msg) : base(msg)
        {

        }
    }
}
