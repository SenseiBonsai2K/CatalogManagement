using Application.DTOs;
using Application.Requests;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        public readonly CategoryService categoryService;

        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("GetCategories")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var categories = await categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpPost("AddCategory")]
        public async Task<ActionResult> AddCategory([FromBody] AddCategoryRequest addCategoryRequest)
        {
            var category = addCategoryRequest.ToEntity();
            try
            {
                await categoryService.AddCategory(category);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            return Ok(category.Name + " Added");
        }
    }
}
