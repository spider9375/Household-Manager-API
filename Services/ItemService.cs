using AutoMapper;
using HouseholdManagerApi.DTOs;
using HouseholdManagerApi.Interfaces.Repositories;
using HouseholdManagerApi.Interfaces.Services;
using HouseholdManagerApi.Models;

namespace HouseholdManagerApi.Services
{
    public class ItemService : IItemService
    {
        private readonly IMapper mapper;
        private readonly IITemRepository itemRepository;
        public ItemService(IITemRepository itemRepository,
            IMapper mapper) {
            this.mapper = mapper;
            this.itemRepository = itemRepository;
                }
        public async Task<ItemDTO> Create(ItemDTO dto, string userId)
        {
            var entity = this.mapper.Map<Item>(dto);
            entity.UserId = userId;
            var result = await this.itemRepository.Create(entity);

            return this.mapper.Map<ItemDTO>(result);
        }

        public async Task Delete(int id, string userId)
        {
            var item = await this.GetById(id, userId);

            if (item != null)
            {
                await this.itemRepository.Delete(id);

            }
        }

        public async Task<IEnumerable<ItemDTO>> GetAll(string userId)
        {
            var result = this.itemRepository.GetAll()
                .Where(i => i.UserId == userId)
                .AsEnumerable();

            return this.mapper.Map<IEnumerable<ItemDTO>>(result);
        }

        public async Task<ItemDTO> GetById(int id, string userId)
        {
            var entity = await this.itemRepository.GetById(id);

            if (entity.UserId != userId)
            {
                throw new Exception("userId mismatch");
            }

            return this.mapper.Map<ItemDTO>(await this.itemRepository.GetById(id));
        }

        public async Task<ItemDTO> Update(ItemDTO entity, string userId)
        {
            var item = await this.GetById(entity.Id.Value, userId);

            if (item == null)
            {
                return null;
            }

            var res = await this.itemRepository.Update(this.mapper.Map<Item>(entity));

            return this.mapper.Map<ItemDTO>(res);
        }
    }
}
