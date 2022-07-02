using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
   public class ScreenFrequency:BaseEntity
    {
        public string Frequency { get; set; }
        public List<ProductParametr> ProductParametrs { get; set; }
    }
}
