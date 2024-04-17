using HouseholdManagerApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using HouseholdManagerApi.Models;

namespace HouseholdManagerApi.Repositories
{
    public class ItemRepository(HomeInventoryContext dbContext) : IITemRepository
    {
        private readonly HomeInventoryContext dbContext = dbContext;

        public async Task<Item> Create(Item entity)
        {
            await this.dbContext.Items.AddAsync(entity);
            await this.dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(int id)
        {
            var tag = await this.dbContext.Items.FirstOrDefaultAsync(saving => saving.Id == id);

            if (tag != null)
            {
                dbContext.Items.Remove(tag);
                await dbContext.SaveChangesAsync();
            }
        }

        public IQueryable<Item> GetAll()
        {
            return this.dbContext.Items.AsQueryable();
        }

        public async Task<Item> GetById(int id)
        {
            var result = await this.dbContext.Items.FirstOrDefaultAsync(s => s.Id == id);

            return result;
        }

        public async Task<Item> Update(Item entity)
        {
            var result = await this.dbContext.Items.FirstOrDefaultAsync(s => s.Id == entity.Id);

            if (result != null)
            {
                result.Name = entity.Name;
                result.UnitOfMeasure = entity.UnitOfMeasure;
                result.ExpirationDate = entity.ExpirationDate;
                result.TagId = entity.TagId;
                result.Quantity = entity.Quantity;

                await this.dbContext.SaveChangesAsync();

                return result;
            }


            return null;
        }
    }
}
