﻿using CompStore.Service.Dtos.Area.MainSliders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface IMainSliderCreateServices
    {
        Task CreateMainSlider(MainSliderCreateDto MainSliderDto);

    }
}
