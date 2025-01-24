using CatalogManagement.Models.Entities;
using CatalogManagement.Models.GeneralRepository;
using MenuManager.Models.Context;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> ApparelExistsByName(string name)
        {
            return await _context.Apparels.AnyAsync(c => c.Name == name);
        }
    }
}
