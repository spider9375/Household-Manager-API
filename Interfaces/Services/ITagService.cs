using HouseholdManagerApi.DTOs;

namespace HouseholdManagerApi.Interfaces.Services
{
    public interface ITagService
    {
        Task<IEnumerable<TagDTO>> GetAll(string userId);
        Task<TagDTO> GetById(int id, string userId);
        Task<TagDTO> Create(TagDTO dto, string userId);
        Task<TagDTO> Update(TagDTO dto, string userId);
        Task Delete(int id, string userId);
    }
}
