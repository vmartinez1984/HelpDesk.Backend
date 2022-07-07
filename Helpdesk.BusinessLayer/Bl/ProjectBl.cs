using AutoMapper;
using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Core.Interfaces.IRepositories;

namespace Helpdesk.BusinessLayer.Bl
{
    public class ProjectBl : IProjectBl
    {
        private IRepository _repository;
        private IMapper _mapper;

        public ProjectBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> AddAsync(ProjectDtoIn item)
        {
            ProjectEntity entity;

            entity = _mapper.Map<ProjectEntity>(item);
            entity.Id = await _repository.Project.AddAsync(entity);

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.Project.DeleteAsync(id, 1);
        }

        public async Task<ProjectDtoOut> GetAsync(int id)
        {
            ProjectEntity entity;
            ProjectDtoOut item;

            entity = await _repository.Project.GetAsync(id);
            item = _mapper.Map<ProjectDtoOut>(entity);
            await SetUserNameAsync(item);
            await SetTotalAgenciesAsync(item);

            return item;
        }

        private async Task SetTotalAgenciesAsync(ProjectDtoOut item)
        {
            var agencyPager = await _repository.Agency.GetAsync(new AgencySearchEntity
            {
                ProjectId = item.Id,
                PageCurrent = 1,
                RecordsPerPage = 10
            });
            item.TotalAgencies = agencyPager.TotalRecords;
        }

        private async Task SetUserNameAsync(ProjectDtoOut item)
        {
            UserEntity userEntity;
            PersonEntity person;


            userEntity = await _repository.User.GetAsync(item.UserId);
            person = await _repository.Person.GetAsync(userEntity.PersonId);

            item.UserName = $"{person.Name} {person.LastName}";
        }

        public async Task<List<ProjectDtoOut>> GetAsync()
        {
            List<ProjectDtoOut> list;
            List<ProjectEntity> entities;

            entities = await _repository.Project.GetAsync();
            list = _mapper.Map<List<ProjectDtoOut>>(entities);

            return list;
        }

        public async Task UpdateAsync(ProjectDtoIn item, int id)
        {
            ProjectEntity entity;

            entity = await _repository.Project.GetAsync(id);
            entity.Name = item.Name;
            entity.Notes = item.Notes;

            await _repository.Project.UpdateAsync(entity);
        }
    }
}