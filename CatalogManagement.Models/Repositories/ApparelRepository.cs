﻿using CatalogManagement.Models.Entities;
using CatalogManagement.Models.GeneralRepository;
using MenuManager.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Models.Repositories
{
    public class ApparelRepository : GeneralRepository<Apparel>
    {
        public ApparelRepository(MyDbContext _context) : base(_context) { }
    }
}
