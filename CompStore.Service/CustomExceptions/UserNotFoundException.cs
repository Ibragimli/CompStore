using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.CustomExceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string msg) : base(msg)
        {

        }
    }
}
