using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class ScreenDiagonal:BaseEntity
    {
        public List<ProductParametr> ProductParametrs { get; set; }
        public string Diagonal { get; set; }
    }
}
