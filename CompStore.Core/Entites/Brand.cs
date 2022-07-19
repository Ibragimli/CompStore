using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<CategoryBrandId> CategoryBrandIds { get; set; }
    }
}
