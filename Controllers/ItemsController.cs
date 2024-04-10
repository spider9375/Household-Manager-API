using Microsoft.AspNetCore.Mvc;
using HouseholdManagerApi.Models;
using HouseholdManagerApi.DTOs;
using HouseholdManagerApi.Interfaces.Services;

namespace HouseholdManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController(IItemService itemService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetAllTags()
        {
            return Ok(await itemService.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ItemDTO>> GetOne(int id)
        {
            return Ok(await itemService.GetById(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ItemDTO>> Create(ItemDTO tag)
        {
            return await itemService.Create(tag);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<ItemDTO>> Update(int id, ItemDTO tag)
        {
            if (id != tag.Id)
            {
                return BadRequest("Id mismatch");
            }

            return await itemService.Update(tag);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await itemService.Delete(id);

            return Ok();
        }
    }
}
