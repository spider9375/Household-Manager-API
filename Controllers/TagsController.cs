using Microsoft.AspNetCore.Mvc;
using HouseholdManagerApi.DTOs;
using HouseholdManagerApi.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using HouseholdManagerApi.ExtensionMethods;

namespace HouseholdManagerApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TagsController(ITagService tagService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagDTO>>> GetAllTags()
        {
            return Ok(await tagService.GetAll(this.GetUserIdFromJwtToken()));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<TagDTO>> GetOne(int id)
        {
            return Ok(await tagService.GetById(id, this.GetUserIdFromJwtToken()));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<TagDTO>> Create(TagDTO tag)
        {
            return await tagService.Create(tag, this.GetUserIdFromJwtToken());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<TagDTO>> Update(int id, TagDTO tag)
        {
            if (id != tag.Id)
            {
                return BadRequest("Id mismatch");
            }

            return await tagService.Update(tag, this.GetUserIdFromJwtToken());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await tagService.Delete(id, this.GetUserIdFromJwtToken());

            return Ok();
        }
    }
}
