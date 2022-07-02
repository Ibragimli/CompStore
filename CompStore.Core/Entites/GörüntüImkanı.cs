using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class GörüntüImkanı : BaseEntity
    {
        public string Capability { get; set; }
        public List<ProductParametr> ProductParametrs { get; set; }

    }
}
