using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly HomeInventoryContext dbContext;

        public TagsController(HomeInventoryContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetAllTags()
        {
            Console.WriteLine("test");
            var res = dbContext.Tags.AsEnumerable();
            return Ok(res);
        }
    }
}
