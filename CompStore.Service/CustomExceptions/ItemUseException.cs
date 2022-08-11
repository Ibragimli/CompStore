using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.CustomExceptions
{
    public class ItemUseException : Exception
    {
        public ItemUseException(string msg) : base(msg)
        {

        }
    }
}
