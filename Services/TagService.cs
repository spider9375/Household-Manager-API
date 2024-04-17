using AutoMapper;
using HouseholdManagerApi.DTOs;
using HouseholdManagerApi.Interfaces.Repositories;
using HouseholdManagerApi.Interfaces.Services;
using HouseholdManagerApi.Models;

namespace HouseholdManagerApi.Services
{
    public class TagService : ITagService
    {
        private readonly IMapper mapper;
        private readonly ITagRepository tagRepository;
        public TagService(ITagRepository tagRepository,
            IMapper mapper) {
            this.mapper = mapper;
            this.tagRepository = tagRepository;
                }
        public async Task<TagDTO> Create(TagDTO entity)
        {
            var result = await this.tagRepository.Create(this.mapper.Map<Tag>(entity));

            return this.mapper.Map<TagDTO>(result);
        }

        public async Task Delete(int id)
        {
            await this.tagRepository.Delete(id);
        }

        public async Task<IEnumerable<TagDTO>> GetAll()
        {
            var result = this.tagRepository.GetAll();

            return this.mapper.Map<IEnumerable<TagDTO>>(result);
        }

        public async Task<TagDTO> GetById(int id)
        {
            return this.mapper.Map<TagDTO>(await this.tagRepository.GetById(id));
        }

        public async Task<TagDTO> Update(TagDTO entity)
        {
            var res = await this.tagRepository.Update(this.mapper.Map<Tag>(entity));

            return this.mapper.Map<TagDTO>(res);
        }
    }
}
