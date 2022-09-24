using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Repositories
{

    public class MainSliderRepository : Repository<MainSlider>, IMainSliderRepository
    {
        private readonly DataContext _context;

        public MainSliderRepository(DataContext context) : base(context)
        {
            _context = context;
        }

    }
}
