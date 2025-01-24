using Application.DTOs;
using CatalogManagement.Models.Entities;
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

        public async Task<ApparelDTO> GetApparelById(int id)
        {
            var apparel = await _apparelRepository.GetByIdAsync(id);
            return new ApparelDTO(apparel);
        }

        public async Task AddApparel(Apparel apparel)
        {
            if (await _apparelRepository.ApparelExistsByName(apparel.Name))
            {
                throw new InvalidOperationException("An APPAREL with the SAME NAME already exists.");
            }
            await _apparelRepository.AddAsync(apparel);
            await _apparelRepository.SaveAsync();
        }

        public async Task DeleteApparel(int id)
        {
            await _apparelRepository.DeleteAsync(id);
            await _apparelRepository.SaveAsync();
        }

        public async Task UpdateApparel(int id, Apparel apparel)
        {
            var apparelToUpdate = await _apparelRepository.GetByIdAsync(id);

            if (apparelToUpdate == null)
            {
                throw new InvalidOperationException("APPAREL NOT FOUND");
            }

            if (apparelToUpdate.Name != apparel.Name && await _apparelRepository.ApparelExistsByName(apparel.Name))
            {
                throw new InvalidOperationException("An APPAREL with the SAME NAME already exists.");
            }

            apparelToUpdate.Name = apparel.Name;
            apparelToUpdate.Description = apparel.Description;
            apparelToUpdate.Price = apparel.Price;
            apparelToUpdate.Category = apparel.Category;

            await _apparelRepository.UpdateAsync(apparelToUpdate);
            await _apparelRepository.SaveAsync();
        }
    }
}
