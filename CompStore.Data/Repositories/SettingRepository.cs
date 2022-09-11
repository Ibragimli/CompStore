using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Repositories
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        private readonly DataContext context;

        public SettingRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
