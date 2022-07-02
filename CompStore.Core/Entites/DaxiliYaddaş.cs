using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class DaxiliYaddaş : BaseEntity
    {
        public int Cache { get; set; }
        public bool IsHDD { get; set; }
        public bool IsSSD { get; set; }
        public int SSDTypeId { get; set; }
        public int DaxiliYaddasHecmId { get; set; }
        public DaxiliYaddasHecm DaxiliYaddasHecm { get; set; }
        public SSDType SSDType { get; set; }
        public List<ProductParametr> ProductParametrs { get; set; }

    }
}
