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
        public async Task<ItemDTO> Create(ItemDTO entity)
        {
            var result = await this.itemRepository.Create(this.mapper.Map<Item>(entity));

            return this.mapper.Map<ItemDTO>(result);
        }

        public async Task Delete(int id)
        {
            await this.itemRepository.Delete(id);
        }

        public async Task<IEnumerable<ItemDTO>> GetAll()
        {
            var result = await this.itemRepository.GetAll();

            return this.mapper.Map<IEnumerable<Item>,IEnumerable<ItemDTO>>(result);
        }

        public async Task<ItemDTO> GetById(int id)
        {
            return this.mapper.Map<ItemDTO>(await this.itemRepository.GetById(id));
        }

        public async Task<ItemDTO> Update(ItemDTO entity)
        {
            var res = await this.itemRepository.Update(this.mapper.Map<Item>(entity));

            return this.mapper.Map<ItemDTO>(res);
        }
    }
}
