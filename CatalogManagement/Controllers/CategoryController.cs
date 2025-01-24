using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        public  readonly CategoryService categoryService;

        public CategoryController(CategoryService categoryService) 
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var categories = await categoryService.GetCategories();
            return Ok(categories);
        }
    }
}
