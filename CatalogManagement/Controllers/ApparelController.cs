using Application.DTOs;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApparelDTO>>> GetApparels()
        {
            var apparels = await _apparelService.GetApparels();
            return Ok(apparels);
        }
    }
}
