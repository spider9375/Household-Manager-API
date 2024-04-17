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
    public class ItemsController(IItemService itemService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetAllTags()
        {
            // Finds user.
            return Ok(await itemService.GetAll(this.GetUserIdFromJwtToken()));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ItemDTO>> GetOne(int id)
        {
            return Ok(await itemService.GetById(id, this.GetUserIdFromJwtToken()));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ItemDTO>> Create(ItemDTO tag)
        {
            return await itemService.Create(tag, this.GetUserIdFromJwtToken());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<ItemDTO>> Update(int id, ItemDTO tag)
        {
            if (id != tag.Id)
            {
                return BadRequest("Id mismatch");
            }

            return await itemService.Update(tag, this.GetUserIdFromJwtToken());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await itemService.Delete(id, this.GetUserIdFromJwtToken());

            return Ok();
        }
    }
}
