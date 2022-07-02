using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class RamGB : BaseEntity
    {
        public List<ProductParametr> ProductParametrs { get; set; }
        public int GB { get; set; }
    }
}
