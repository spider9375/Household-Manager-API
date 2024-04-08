using Microsoft.AspNetCore.Mvc;
using HouseholdManagerApi.Models;
using HouseholdManagerApi.DTOs;
using HouseholdManagerApi.Interfaces.Services;

namespace HouseholdManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController(ITagService tagService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetAllTags()
        {
            return Ok(await tagService.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<TagDTO>> GetOne(int id)
        {
            return Ok(await tagService.GetById(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<TagDTO>> Create(TagDTO saving)
        {
            return await tagService.Create(saving);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<TagDTO>> UpdateSaving(int id, TagDTO saving)
        {
            if (id != saving.Id)
            {
                return BadRequest("Id mismatch");
            }

            return await tagService.Update(saving);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await tagService.Delete(id);

            return Ok();
        }
    }
}
