﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class Model : BaseEntity
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
