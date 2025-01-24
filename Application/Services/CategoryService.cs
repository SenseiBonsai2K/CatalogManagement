using Application.DTOs;
using CatalogManagement.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoryService
    {
        public readonly CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = new List<CategoryDTO>();
            foreach (var category in await _categoryRepository.GetAllAsync())
            {
                categories.Add(new CategoryDTO(category));
            }
            return categories;
        }
    }
}
