using AutoMapper;
using HouseholdManagerApi.DTOs;
using HouseholdManagerApi.Interfaces.Repositories;
using HouseholdManagerApi.Interfaces.Services;
using HouseholdManagerApi.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<TagDTO> Create(TagDTO dto, string userId)
        {
            var entity = this.mapper.Map<Tag>(dto);
            entity.UserId = userId;
            var result = await this.tagRepository.Create(this.mapper.Map<Tag>(entity));

            return this.mapper.Map<TagDTO>(result);
        }

        public async Task Delete(int id, string userId)
        {
            var entity = await this.GetById(id, userId);

            if (entity == null)
            {
                return;
            }

            await this.tagRepository.Delete(id);
        }

        public async Task<IEnumerable<TagDTO>> GetAll(string userId)
        {
            var result = await this.tagRepository.GetAll().Where(x => x.UserId == userId).ToListAsync();

            return this.mapper.Map<IEnumerable<TagDTO>>(result);
        }

        public async Task<TagDTO> GetById(int id, string userId)
        {
            return this.mapper.Map<TagDTO>(this.tagRepository.GetAll().FirstOrDefault(x => x.Id == id && x.UserId == userId));
        }

        public async Task<TagDTO> Update(TagDTO dto, string userId)
        {
            var entity = await this.GetById(dto.Id.Value, userId);

            if (entity == null)
            {
                return null;
            }

            var res = await this.tagRepository.Update(this.mapper.Map<Tag>(dto));

            return this.mapper.Map<TagDTO>(res);
        }
    }
}
