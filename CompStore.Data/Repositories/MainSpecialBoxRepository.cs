﻿using CompStore.Core.Entites;
using CompStore.Core.Repositories;
using CompStore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Repositories
{
    public class MainSpecialBoxRepository : Repository<MainSpecialBox>, IMainSpecialBoxRepository
    {
        private readonly DataContext _context;

        public MainSpecialBoxRepository(DataContext context) : base(context)
        {
            _context = context;
        }

    }
}
