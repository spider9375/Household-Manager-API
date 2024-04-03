using HouseholdManagerApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController(HomeInventoryContext dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetAllTags()
        {
            var res = dbContext.Tags.AsEnumerable();
            return Ok(res);
        }
    }
}
