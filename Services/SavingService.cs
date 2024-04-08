using AutoMapper;
using HouseholdManagerApi.DTOs;
using HouseholdManagerApi.Interfaces.Repositories;
using HouseholdManagerApi.Interfaces.Services;
using HouseholdManagerApi.Models;

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
        public async Task<SavingDTO> Create(SavingDTO entity)
        {
            var result = await this.savingRepository.Create(this.mapper.Map<Saving>(entity));

            return this.mapper.Map<SavingDTO>(result);
        }

        public async Task Delete(int id)
        {
            await this.savingRepository.Delete(id);
        }

        public async Task<IEnumerable<SavingDTO>> GetAll()
        {
            var result = await this.savingRepository.GetAll();

            return this.mapper.Map<IEnumerable<Saving>,IEnumerable<SavingDTO>>(result);
        }

        public async Task<SavingDTO> GetById(int id)
        {
            return this.mapper.Map<SavingDTO>(await this.savingRepository.GetById(id));
        }

        public async Task<SavingDTO> Update(SavingDTO entity)
        {
            var res = await this.savingRepository.Update(this.mapper.Map<Saving>(entity));

            return this.mapper.Map<SavingDTO>(res);
        }
    }
}
