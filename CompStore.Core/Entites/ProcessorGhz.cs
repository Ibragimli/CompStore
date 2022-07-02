using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
   public class ProcessorGhz:BaseEntity
    {
        public int Ghz { get; set; }
        public List<ProductParametr> ProductParametrs { get; set; }

    }
}
