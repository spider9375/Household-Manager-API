using HouseholdManagerApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using HouseholdManagerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseholdManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController(HomeInventoryContext dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetAllTags()
        {
            var res = await dbContext.Tags.ToListAsync();
            return Ok(res);
        }
    }
}
