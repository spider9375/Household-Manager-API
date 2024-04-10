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
            var newEntity = new Item()
            {
                Name = entity.Name,
                TagId = entity.TagId,
                ExpirationDate = entity.ExpirationDate,
                //ExpirationDate = entity.ExpirationDate != null ? DateTime.SpecifyKind(entity.ExpirationDate.Value, DateTimeKind.Utc) : null,
                Quantity = entity.Quantity,
                UnitOfMeasure = entity.UnitOfMeasure,
            };

            this.dbContext.Items.Add(newEntity);

            await this.dbContext.SaveChangesAsync();

            return newEntity;
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

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await this.dbContext.Items.ToListAsync();
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
                //result.ExpirationDate = entity.ExpirationDate != null ? DateTime.SpecifyKind(entity.ExpirationDate.Value, DateTimeKind.Utc) : null;
                result.TagId = entity.TagId;
                result.Quantity = entity.Quantity;

                await this.dbContext.SaveChangesAsync();

                return result;
            }


            return null;
        }
    }
}
