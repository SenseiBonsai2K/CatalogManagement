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

        [HttpDelete("DeleteCategory")]
        public async Task<ActionResult> DeleteCategory([FromQuery] int id)
        {
            var category = await categoryService.GetCategoryById(id);
            try
            {
                await categoryService.DeleteCategory(id);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Category " + category.Name + " Deleted");
        }

        [HttpPut("UpdateCategory")]
        public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryRequest updateCategoryRequest)
        {
            var newCategory = updateCategoryRequest.AddCategoryRequest.ToEntity();
            try
            {
                await categoryService.UpdateCategory(updateCategoryRequest.Id, newCategory);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            return Ok(newCategory.Name + " Updated");
        }
    }
}
