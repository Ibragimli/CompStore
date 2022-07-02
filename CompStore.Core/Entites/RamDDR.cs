using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class RamDDR : BaseEntity
    {
        public string DDR { get; set; }
        public List<ProductParametr> ProductParametrs { get; set; }
    }
}
