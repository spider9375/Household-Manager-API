using HouseholdManagerApi.DTOs;

namespace HouseholdManagerApi.Interfaces.Services
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDTO>> GetAll(string userId);
        Task<ItemDTO> GetById(int id, string userId);
        Task<ItemDTO> Create(ItemDTO dto, string userId);
        Task<ItemDTO> Update(ItemDTO dto, string userId);
        Task Delete(int id, string userId);
    }
}
