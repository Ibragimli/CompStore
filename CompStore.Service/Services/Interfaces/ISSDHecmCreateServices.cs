﻿using CompStore.Service.Dtos.Area.SSDHecms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface ISSDHecmCreateServices
    {
        Task CreateGB(SSDHecmCreateDto brandDto);

    }
}
