using HouseholdManagerApi.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace HouseholdManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingsController: ControllerBase
    {
        private readonly ISavingRepository savingRepository;
        public SavingsController(ISavingRepository savingRepository)
        {
            this.savingRepository = savingRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Saving>>> GetAllSavings()
        {
            return Ok(await this.savingRepository.GetAll());
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<Saving>> UpdateSaving(Guid id, Saving saving)
        {
            if (id != saving.Id)
            {
                return BadRequest("Id mismatch");
            }

            var savingToUpdate = this.savingRepository.GetById(id);

            if (savingToUpdate == null)
            {
                return NotFound();
            }

            return await this.savingRepository.Update(saving);
        }
    }
}
