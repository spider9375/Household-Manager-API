using HouseholdManagerApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using HouseholdManagerApi.Models;

namespace HouseholdManagerApi.Repositories
{
    public class TagRepository(HomeInventoryContext dbContext) : ITagRepository
    {
        private readonly HomeInventoryContext dbContext = dbContext;

        public async Task<Tag> Create(Tag entity)
        {
            this.dbContext.Tags.Add(entity);

            await this.dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(int id)
        {
            var tag = await this.dbContext.Tags.FirstOrDefaultAsync(saving => saving.Id == id);

            if (tag != null)
            {
                dbContext.Tags.Remove(tag);
                await dbContext.SaveChangesAsync();
            }
        }

        public IQueryable<Tag> GetAll()
        {
            return this.dbContext.Tags.AsQueryable();
        }

        public async Task<Tag> GetById(int id)
        {
            var result = await this.dbContext.Tags.FirstOrDefaultAsync(s => s.Id == id);

            return result;
        }

        public async Task<Tag> Update(Tag entity)
        {
            var result = await this.dbContext.Tags.FirstOrDefaultAsync(s => s.Id == entity.Id);

            if (result != null)
            {
                result.Color = entity.Color;
                result.Name = entity.Name;
                result.Icon = entity.Icon;

                await this.dbContext.SaveChangesAsync();

                return result;
            }


            return null;
        }
    }
}
