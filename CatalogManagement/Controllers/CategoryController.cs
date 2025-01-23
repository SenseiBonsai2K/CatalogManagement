using CatalogManagement.DTOs;
using CatalogManagement.Models.Entities;
using CatalogManagement.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _categoryRepository;
        public CategoryController(CategoryRepository categoryRepository) 
        {
            this._categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var categories = new List<CategoryDTO>();
            foreach (var category in await _categoryRepository.GetAllAsync())
            {
                categories.Add(new CategoryDTO(category));
            }
            return Ok(categories);
        }
    }
}
