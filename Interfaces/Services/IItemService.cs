using HouseholdManagerApi.DTOs;

namespace HouseholdManagerApi.Interfaces.Services
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDTO>> GetAll();
        Task<ItemDTO> GetById(int id);
        Task<ItemDTO> Create(ItemDTO entity);
        Task<ItemDTO> Update(ItemDTO entity);
        Task Delete(int id);
    }
}
