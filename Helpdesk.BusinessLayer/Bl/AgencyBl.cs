using AutoMapper;
using Helpdesk.Core.Dtos;
using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Core.Interfaces.IRepositories;
using Newtonsoft.Json;

namespace Helpdesk.BusinessLayer.Bl
{
    public class AgencyBl : IAgencyBl
    {
        private IRepository _repository;
        private IMapper _mapper;

        public AgencyBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(AgencyDtoIn item)
        {
            AgencyEntity entity;

            entity = _mapper.Map<AgencyEntity>(item);
            entity.Id = await _repository.Agency.AddAsync(entity);

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.Agency.DeleteAsync(id, 1);
        }

        public async Task<AgencyDtoOut> GetAsync(int id)
        {
            AgencyDtoOut item;
            AgencyEntity entity;

            entity = await _repository.Agency.GetAsync(id);
            if (entity is null)
                return null;
            item = _mapper.Map<AgencyDtoOut>(entity);
            var agencyType = await _repository.AgencyType.GetAsync(item.AgencyTypeId);
            item.AgencyType = _mapper.Map<AgencyTypeDtoOut>(agencyType);
            var project = await _repository.Project.GetAsync(item.ProjectId);
            item.ProjectName = project.Name;
            await SetUserNameAsync(item);

            return item;
        }

        private async Task SetUserNameAsync(AgencyDtoOut item)
        {
            UserEntity userEntity;
            PersonEntity personEntity;

            userEntity = await _repository.User.GetAsync(item.UserId);
            personEntity = await _repository.Person.GetAsync(userEntity.PersonId);

            item.UserName = $"{personEntity.Name} {personEntity.LastName}";
        }

        public async Task<AgencyListDtoOut> GetAsync(SearchDtoIn searchDto)
        {
            AgencyListDtoOut response;
            PagerEntity pagerEntity;
            List<AgencyEntity> entities;

            pagerEntity = _mapper.Map<PagerEntity>(searchDto);
            entities = await _repository.Agency.GetAsync(pagerEntity);
            response = new AgencyListDtoOut
            {
                ListAgencies = _mapper.Map<List<AgencyDtoOut>>(entities),
                PageCurrent = pagerEntity.PageCurrent,
                RecordsPerPage = pagerEntity.RecordsPerPage,
                TotalRecords = pagerEntity.TotalRecords,
                TotalRecordsFiltered = pagerEntity.TotalRecordsFiltered
            };
            await LoadAgencyTypeName(response);

            return response;
        }

        private async Task LoadAgencyTypeName(AgencyListDtoOut agencySearch)
        {
            List<AgencyTypeEntity> listAgencyTypeEntities;

            listAgencyTypeEntities = await _repository.AgencyType.GetAsync();
            agencySearch.ListAgencies?.ForEach(item =>
            {
                AgencyTypeEntity agencyTypeEntity;

                agencyTypeEntity = listAgencyTypeEntities.Where(x => x.Id == item.AgencyTypeId).FirstOrDefault();

                item.AgencyType = _mapper.Map<AgencyTypeDtoOut>(agencyTypeEntity);
            });
        }

        public async Task UpdateAsync(AgencyDtoIn item, int id)
        {
            AgencyEntity entity;

            entity = await _repository.Agency.GetAsync(id);
            var entityUpdate = _mapper.Map<AgencyEntity>(item);
            entity.Address = entityUpdate.Address;
            entity.AgencyTypeId = entityUpdate.AgencyTypeId;
            entity.Code = entityUpdate.Code;
            entity.Email = entityUpdate.Email;
            entity.Log = $"Modificado por {item.UserId}, {DateTime.Now}." + JsonConvert.SerializeObject(entity) + "\n" + entity.Log;
            entity.Name = entityUpdate.Name;
            entity.Notes = entityUpdate.Notes;
            entity.Phone = entityUpdate.Phone;
            entity.ProjectId = entityUpdate.ProjectId;
            entity.Settlement = entityUpdate.Settlement;
            entity.State = entityUpdate.State;
            entity.TownHall = entityUpdate.TownHall;
            entity.ZipCode = entityUpdate.ZipCode;

            await _repository.Agency.UpdateAsync(entity);
        }

        public async Task<List<AgencyDtoOut>> GetByProjectIdAsync(int projectId)
        {
            List<AgencyDtoOut> list;
            List<AgencyEntity> entities;

            entities = await _repository.Agency.GetByProjectIdAsync(projectId);
            list = _mapper.Map<List<AgencyDtoOut>>(entities);

            return list;
        }
    }
}