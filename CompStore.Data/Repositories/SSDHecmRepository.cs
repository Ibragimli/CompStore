using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Repositories
{
    public class SSDHecmRepository : Repository<SSDHecm>, ISSDHecmRepository
    {
        private readonly DataContext context;

        public SSDHecmRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
