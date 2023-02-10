using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Services.Interfaces
{
    public interface IEmailServices
    {
        public void Send(string to, string subject, string html);
    }
}
