using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.CustomExceptions
{

    public class ItemNullException : Exception
    {
        public ItemNullException(string msg) : base(msg)
        {

        }
    }
}
