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

        public async Task<IEnumerable<ApparelDTO>> GetApparelsByCategoryName(string name)
        {
            var apparels = new List<ApparelDTO>();
            foreach (var apparel in await _apparelRepository.GetApparelsByCategoryName(name))
            {
                apparels.Add(new ApparelDTO(apparel));
            }
            return apparels;
        }

        public async Task AddApparel(Apparel apparel)
        {
            ValidateIfInputNotNull(apparel);

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

            apparelToUpdate.Name = !string.IsNullOrEmpty(apparel.Name) ? apparel.Name : apparelToUpdate.Name;
            apparelToUpdate.ImageUrl = !string.IsNullOrEmpty(apparel.ImageUrl) ? apparel.ImageUrl : apparelToUpdate.ImageUrl;
            apparelToUpdate.Size = !string.IsNullOrEmpty(apparel.Size) ? apparel.Size : apparelToUpdate.Size;
            apparelToUpdate.Material = !string.IsNullOrEmpty(apparel.Material) ? apparel.Material : apparelToUpdate.Material;
            apparelToUpdate.Brand = !string.IsNullOrEmpty(apparel.Brand) ? apparel.Brand : apparelToUpdate.Brand;
            apparelToUpdate.Description = !string.IsNullOrEmpty(apparel.Description) ? apparel.Description : apparelToUpdate.Description;
            apparelToUpdate.Price = apparel.Price > 0 ? apparel.Price : apparelToUpdate.Price;
            apparelToUpdate.Category = apparel.Category ?? apparelToUpdate.Category;

            await _apparelRepository.UpdateAsync(apparelToUpdate);
            await _apparelRepository.SaveAsync();
        }

        public async Task<IEnumerable<ApparelDTO>> GetApparelsByName(string name)
        {
            var apparels = new List<ApparelDTO>();
            foreach (var apparel in await _apparelRepository.GetApparelsByName(name))
            {
                apparels.Add(new ApparelDTO(apparel));
            }
            return apparels;
        }

        public void ValidateIfInputNotNull(Apparel apparel)
        {
            if (apparel == null)
            {
                throw new InvalidOperationException("APPAREL is NULL");
            }
            if (string.IsNullOrEmpty(apparel.Name))
            {
                throw new InvalidOperationException("APPAREL NAME is NULL or EMPTY");
            }
            if (string.IsNullOrEmpty(apparel.ImageUrl))
            {
                throw new InvalidOperationException("APPAREL IMAGE URL is NULL or EMPTY");
            }
            if (string.IsNullOrEmpty(apparel.Size))
            {
                throw new InvalidOperationException("APPAREL SIZE is NULL or EMPTY");
            }
            if (string.IsNullOrEmpty(apparel.Material))
            {
                throw new InvalidOperationException("APPAREL MATERIAL is NULL or EMPTY");
            }
            if (string.IsNullOrEmpty(apparel.Brand))
            {
                throw new InvalidOperationException("APPAREL BRAND is NULL or EMPTY");
            }
            if (apparel.Price <= 0)
            {
                throw new InvalidOperationException("APPAREL PRICE is 0 or NEGATIVE");
            }
        }
    }
}
