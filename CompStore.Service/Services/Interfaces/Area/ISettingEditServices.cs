using CompStore.Service.Dtos.Area.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces.Area
{
    public interface ISettingEditServices
    {
        Task SettingEdit(SettingEditDto SettingEdit);
        Task<SettingEditDto> IsExists(int id);
        Task<SettingEditDto> GetSearch(int Id);

    }
}
