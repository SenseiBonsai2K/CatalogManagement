using Application.DTOs;
using Application.Requests;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApparelController : Controller
    {
        public readonly ApparelService _apparelService;
        public readonly CategoryService _categoryService;

        public ApparelController(ApparelService apparelService, CategoryService categoryService)
        {
            this._apparelService = apparelService;
            _categoryService = categoryService;
        }

        [HttpGet("GetApparels")]
        public async Task<ActionResult<IEnumerable<ApparelDTO>>> GetApparels()
        {
            var apparels = await _apparelService.GetApparels();
            return Ok(apparels);
        }

        [HttpGet("GetApparelsByName")]
        public async Task<ActionResult<IEnumerable<ApparelDTO>>> GetApparelsByName([FromQuery] string name)
        {
            var apparels = await _apparelService.GetApparelsByName(name);
            return Ok(apparels);
        }


        [HttpPost("AddApparel")]
        public async Task<ActionResult> AddApparel([FromBody] AddApparelRequest addApparelRequest)
        {
            var apparel = addApparelRequest.ToEntity();
            try
            {
                await _apparelService.AddApparel(apparel);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            return Ok(apparel.Name + " Added");
        }

        [HttpDelete("DeleteApparel")]
        public async Task<ActionResult> DeleteApparel([FromQuery] int id)
        {
            var apparel = await _apparelService.GetApparelById(id);
            try
            {
                await _apparelService.DeleteApparel(id);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Apparel " + apparel.Name + " Deleted");
        }

        [HttpPut("UpdateApparel")]
        public async Task<ActionResult> UpdateApparel([FromBody] UpdateApparelRequest updateApparelRequest)
        {
            var newApparel = updateApparelRequest.AddApparelRequest.ToEntity();
            try
            {
                await _apparelService.UpdateApparel(updateApparelRequest.Id, newApparel);
                await _categoryService.AddApparelToCategory(newApparel.CategoryId, updateApparelRequest.Id);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Apparel " + newApparel.Name + " Updated");
        }
    }
}
