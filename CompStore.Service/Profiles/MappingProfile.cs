using CompStore.Core.Entites;
using CompStore.Service.Dtos.Area.Brands;
using CompStore.Service.HelperService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CompStore.Service.Dtos.User;

namespace CompStore.Service.Profiles
{
    public class MappingProfile : Profile
    {
        private readonly IHelperAccessor _helperAccessor;

        public MappingProfile(IHelperAccessor helperAccessor)
        {
            _helperAccessor = helperAccessor;

            CreateMap<Brand, BrandListItemDto>();
            CreateMap<Brand, BrandEditDto>();
            CreateMap<ContactUs, ContactUsPostDto>();

        }
    }
}
