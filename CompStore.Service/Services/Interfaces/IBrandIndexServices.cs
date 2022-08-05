using CompStore.Service.Dtos;
using CompStore.Service.Dtos.Area.Brands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompStore.Service.Services.Interfaces
{
    public interface IBrandIndexServices
    {
        Task<PagenatedListDto<BrandListItemDto>> GetAllFiltered(int pageIndex, int pageSize, string search);

    }
}
