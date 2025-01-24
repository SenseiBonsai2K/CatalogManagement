using Application.DTOs;
using CatalogManagement.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApparelService
    {
        public readonly ApparelRepository _apparelRepository;

        public ApparelService(ApparelRepository apparelRepository)
        {
            this._apparelRepository = apparelRepository;
        }

        public async Task<IEnumerable<ApparelDTO>> GetApparels()
        {
            var apparels = new List<ApparelDTO>();
            foreach (var apparel in await _apparelRepository.GetAllAsync())
            {
                apparels.Add(new ApparelDTO(apparel));
            }
            return apparels;
        }
    }
}
