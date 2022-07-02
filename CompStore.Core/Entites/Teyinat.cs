using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class Teyinat : BaseEntity
    {
        public string Type { get; set; }
        public List<ProductParametr> ProductParametrs { get; set; }
    }
}
