using Application.DTOs;
using CatalogManagement.Models.Entities;
using CatalogManagement.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Application.Services
{
    public class CategoryService
    {
        public readonly CategoryRepository _categoryRepository;
        public readonly ApparelRepository _apparelRepository;

        public CategoryService(CategoryRepository categoryRepository, ApparelRepository apparelRepository)
        {
            this._categoryRepository = categoryRepository;
            _apparelRepository = apparelRepository;
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

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return new CategoryDTO(category);
        }

        public async Task AddCategory(Category category)
        {
            if (await _categoryRepository.CategoryExistsByName(category.Name))
            {
                throw new InvalidOperationException("A CATEGORY with the SAME NAME already exists.");
            }
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveAsync();
        }

        public async Task DeleteCategory(int id)
        {
            var apparels = await _apparelRepository.GetApparelsByCategoryId(id);
            var category = await _categoryRepository.GetByIdAsync(id);
            if (apparels.Any())
            {
                throw new InvalidOperationException("CATEGORY is in USE in one or more apparel");
            }
            await _categoryRepository.DeleteAsync(category.Id);
            await _categoryRepository.SaveAsync();
        }

        public async Task UpdateCategory(int id, Category category)
        {
            var categoryToUpdate = await _categoryRepository.GetByIdAsync(id);
            if (await _categoryRepository.CategoryExistsByName(category.Name))
            {
                throw new InvalidOperationException("A CATEGORY with the SAME NAME already exists.");
            }
            categoryToUpdate.Name = category.Name;
            await _categoryRepository.UpdateAsync(categoryToUpdate);
            await _categoryRepository.SaveAsync();
        }
    }
}
