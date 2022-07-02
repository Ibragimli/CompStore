using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class ProcessorCache : BaseEntity
    {
        public List<ProductParametr> ProductParametrs { get; set; }
        public double Cache { get; set; }
    }
}
