using HouseholdManagerApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace HouseholdManagerApi.Repositories
{
    public class SavingRepository(HomeInventoryContext dbContext) : ISavingRepository
    {
        private readonly HomeInventoryContext dbContext = dbContext;

        public Task<Saving> Create(Saving entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            var saving = this.dbContext.Savings.FirstOrDefault(saving => saving.Id == id);

            if (saving != null)
            {
                dbContext.Savings.Remove(saving);
                dbContext.SaveChanges();
            }
        }

        public async Task<IEnumerable<Saving>> GetAll()
        {
            return await this.dbContext.Savings.ToListAsync();
        }

        public Task<Saving> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Saving> Update(Saving entity)
        {
            throw new NotImplementedException();
        }
    }
}
