using HouseholdManagerApi.DTOs;
using HouseholdManagerApi.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingsController: ControllerBase
    {
        private readonly ISavingService savingService;
        public SavingsController(ISavingService savingService)
        {
            this.savingService = savingService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SavingDTO>>> GetAllSavings()
        {
            return Ok(await this.savingService.GetAll());
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<SavingDTO>> UpdateSaving(Guid id, SavingDTO saving)
        {
            if (id != saving.Id)
            {
                return BadRequest("Id mismatch");
            }

            return await this.savingService.Update(saving);
        }
    }
}
