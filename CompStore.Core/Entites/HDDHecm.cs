using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class HDDHecm : BaseEntity
    {
        public List<DaxiliYaddaş> DaxiliYaddaşs { get; set; }
        public string Cache { get; set; }
    }
}
