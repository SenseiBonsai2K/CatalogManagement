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

        public ApparelController(ApparelService apparelService)
        {
            this._apparelService = apparelService;
        }

        [HttpGet("GetApparels")]
        public async Task<ActionResult<IEnumerable<ApparelDTO>>> GetApparels()
        {
            var apparels = await _apparelService.GetApparels();
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
    }
}
