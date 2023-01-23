using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class ContactUs : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
 
    }
}
