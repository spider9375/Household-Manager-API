﻿using HouseholdManagerApi.DTOs;
using HouseholdManagerApi.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<SavingDTO>> GetOne(int id)
        {
            return Ok(await this.savingService.GetById(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<SavingDTO>> Create(SavingDTO saving)
        {
            return await this.savingService.Create(saving);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<SavingDTO>> UpdateSaving(int id, SavingDTO saving)
        {
            if (id != saving.Id)
            {
                return BadRequest("Id mismatch");
            }

            return await this.savingService.Update(saving);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await this.savingService.Delete(id);

            return Ok();
        }
    }
}
