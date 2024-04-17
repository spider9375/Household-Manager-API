using HouseholdManagerApi.DTOs;

namespace HouseholdManagerApi.Interfaces.Services
{
    public interface ISavingService
    {
        Task<IEnumerable<SavingDTO>> GetAll(string userId);
        Task<SavingDTO> GetById(int id, string userId);
        Task<SavingDTO> Create(SavingDTO dto, string userId);
        Task<SavingDTO> Update(SavingDTO dto, string userId);
        Task Delete(int id, string userId);
    }
}
