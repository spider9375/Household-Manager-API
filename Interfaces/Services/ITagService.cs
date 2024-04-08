using HouseholdManagerApi.DTOs;

namespace HouseholdManagerApi.Interfaces.Services
{
    public interface ITagService
    {
        Task<IEnumerable<TagDTO>> GetAll();
        Task<TagDTO> GetById(int id);
        Task<TagDTO> Create(TagDTO entity);
        Task<TagDTO> Update(TagDTO entity);
        Task Delete(int id);
    }
}
