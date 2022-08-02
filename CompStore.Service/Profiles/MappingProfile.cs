using CompStore.Service.HelperService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Profiles
{
    public class MappingProfile
    {
        private readonly IHelperAccessor _helperAccessor;

        public MappingProfile(IHelperAccessor helperAccessor)
        {
            _helperAccessor = helperAccessor;
          
        }
    }
}
