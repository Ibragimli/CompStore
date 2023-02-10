using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class EmailSetting : BaseEntity
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpEmail { get; set; }
        public string SmtpPassword { get; set; }
    }
}
