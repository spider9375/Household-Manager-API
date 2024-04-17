using AutoMapper;
using HouseholdManagerApi.DTOs;
using HouseholdManagerApi.Interfaces.Repositories;
using HouseholdManagerApi.Interfaces.Services;
using HouseholdManagerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseholdManagerApi.Services
{
    public class SavingService : ISavingService
    {
        private readonly IMapper mapper;
        private readonly ISavingRepository savingRepository;
        public SavingService(ISavingRepository savingRepository,
            IMapper mapper) {
            this.mapper = mapper;
            this.savingRepository = savingRepository;
                }
        public async Task<SavingDTO> Create(SavingDTO dto, string userId)
        {
            var entity = this.mapper.Map<Saving>(dto);
            entity.UserId = userId;
            var result = await this.savingRepository.Create(entity);

            return this.mapper.Map<SavingDTO>(result);
        }

        public async Task Delete(int id, string userId)
        {
            var item = await this.GetById(id, userId);

            if (item == null)
            {
                return;
            }

            await this.savingRepository.Delete(id);
        }

        public async Task<IEnumerable<SavingDTO>> GetAll(string userId)
        {
            var result = await this.savingRepository.GetAll().Where(s => s.UserId == userId).ToListAsync();

            return this.mapper.Map<IEnumerable<Saving>,IEnumerable<SavingDTO>>(result);
        }

        public async Task<SavingDTO> GetById(int id, string userId)
        {
            return this.mapper.Map<SavingDTO>(await this.savingRepository.GetAll().FirstOrDefaultAsync(s => s.UserId == userId && s.Id == id));
        }

        public async Task<SavingDTO> Update(SavingDTO dto, string userId)
        {
            var entity = await this.GetById(dto.Id.Value, userId);

            if (entity == null)
            {
                return null;
            }

            var res = await this.savingRepository.Update(this.mapper.Map<Saving>(dto));

            return this.mapper.Map<SavingDTO>(res);
        }
    }
}
