﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
   public class Videokart:BaseEntity
    {
        public string Name { get; set; }
        public List<ProductParametr> ProductParametrs { get; set; }

    }
}
