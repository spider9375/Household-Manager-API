using HouseholdManagerApi.DTOs;

namespace HouseholdManagerApi.Interfaces.Services
{
    public interface ISavingService
    {
        Task<IEnumerable<SavingDTO>> GetAll();
        Task<SavingDTO> GetById(Guid id);
        Task<SavingDTO> Create(SavingDTO entity);
        Task<SavingDTO> Update(SavingDTO entity);
        void Delete(Guid id);
    }
}
