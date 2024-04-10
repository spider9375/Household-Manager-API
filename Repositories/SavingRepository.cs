﻿using HouseholdManagerApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using HouseholdManagerApi.Models;

namespace HouseholdManagerApi.Repositories
{
    public class SavingRepository(HomeInventoryContext dbContext) : ISavingRepository
    {
        private readonly HomeInventoryContext dbContext = dbContext;

        public async Task<Saving> Create(Saving entity)
        {
            var newEntity = new Saving()
            {
                Name = entity.Name,
                Amount = entity.Amount,
                Currency = entity.Currency,
                Goal = entity.Goal,
                TagId = entity.TagId,
            };
            this.dbContext.Savings.Add(newEntity);

            await this.dbContext.SaveChangesAsync();

            return newEntity;
        }

        public async Task Delete(int id)
        {
            var saving = await this.dbContext.Savings.FirstOrDefaultAsync(saving => saving.Id == id);

            if (saving != null)
            {
                dbContext.Savings.Remove(saving);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Saving>> GetAll()
        {
            return await this.dbContext.Savings.ToListAsync();
        }

        public async Task<Saving> GetById(int id)
        {
            var result = await this.dbContext.Savings.FirstOrDefaultAsync(s => s.Id == id);

            return result;
        }

        public async Task<Saving> Update(Saving entity)
        {
            var result = await this.dbContext.Savings.FirstOrDefaultAsync(s => s.Id == entity.Id);

            if (result != null)
            {
                result.Currency = entity.Currency;
                result.TagId = entity.TagId;
                result.Goal = entity.Goal;
                result.Amount = entity.Amount;
                result.Name = entity.Name;

                await this.dbContext.SaveChangesAsync();

                return result;
            }


            return null;
        }
    }
}
