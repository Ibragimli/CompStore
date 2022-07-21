using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class DaxiliYaddaş : BaseEntity
    {
        public bool IsHDD { get; set; }
        public bool IsSSD { get; set; }
        public int? SSDTypeId { get; set; }
        public int? HDDHecmId { get; set; }
        public int? SSDHecmId { get; set; }
        public HDDHecm HDDHecm { get; set; }
        public SSDHecm SSDHecm { get; set; }
        public SSDType SSDType { get; set; }
        public List<ProductParametr> ProductParametrs { get; set; }
    }
}
