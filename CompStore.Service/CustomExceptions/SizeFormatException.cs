using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.CustomExceptions
{
    public class SizeFormatException : Exception
    {
        public SizeFormatException(string msg) : base(msg)
        {

        }
    }
}
