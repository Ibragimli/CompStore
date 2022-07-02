using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class RamMhz:BaseEntity
    {
        public List<ProductParametr> ProductParametrs { get; set; }
        public int Mhz { get; set; }
    }
}
