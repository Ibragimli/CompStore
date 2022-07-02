using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class OperationSystem : BaseEntity
    {
        public List<ProductParametr> ProductParametrs { get; set; }
        public string System { get; set; }
    }
}
