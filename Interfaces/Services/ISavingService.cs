using HouseholdManagerApi.DTOs;

namespace HouseholdManagerApi.Interfaces.Services
{
    public interface ISavingService
    {
        Task<IEnumerable<SavingDTO>> GetAll();
        Task<SavingDTO> GetById(int id);
        Task<SavingDTO> Create(SavingDTO entity);
        Task<SavingDTO> Update(SavingDTO entity);
        Task Delete(int id);
    }
}
