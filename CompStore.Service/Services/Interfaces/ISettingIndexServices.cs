using CompStore.Core.Entites;
using CompStore.Service.Dtos.Area.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface ISettingIndexServices
    {
        Task<IQueryable<Setting>> SearchCheck(string search);
    }
}
