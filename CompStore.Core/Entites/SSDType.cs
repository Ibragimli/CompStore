using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class SSDType : BaseEntity
    {
        public List<DaxiliYaddaş> DaxiliYaddaşs { get; set; }
        public string Type { get; set; }
    }
}
