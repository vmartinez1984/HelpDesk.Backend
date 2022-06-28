using AutoMapper;
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
            item = _mapper.Map<AgencyDtoOut>(entity);
            var agencyType = await _repository.AgencyType.GetAsync(item.AgencyTypeId);
            item.AgencyTypeName = agencyType.Name;
            var project = await _repository.Project.GetAsync(item.ProjectId);
            item.ProjectName = project.Name;

            return item;
        }

        public async Task<List<AgencyDtoOut>> GetListAsync(int? projectId)
        {
            List<AgencyDtoOut> list;
            List<AgencyEntity> entities;
            List<AgencyTypeEntity> listAgencyTypeEntities;

            entities = await _repository.Agency.GetListAsync(projectId);
            listAgencyTypeEntities = await _repository.AgencyType.GetAsync();
            list = _mapper.Map<List<AgencyDtoOut>>(entities);
            list.ForEach(item =>
            {
                AgencyTypeEntity agencyTypeEntity;

                agencyTypeEntity = listAgencyTypeEntities.Where(x => x.Id == item.AgencyTypeId).FirstOrDefault();
                item.AgencyTypeName = agencyTypeEntity.Name;
            });

            return list;
        }

        public async Task UpdateAsync(AgencyDtoIn item, int id)
        {
            AgencyEntity entity;

            entity = await _repository.Agency.GetAsync(id);
            var entityUpdate = _mapper.Map<AgencyEntity>(item);
            entity.Id = id;
            entity.Address = entityUpdate.Address;
            entity.AgencyTypeId = entityUpdate.AgencyTypeId;
            entity.Code = entityUpdate.Code;
            entity.email = entityUpdate.email;
            entity.Log = $"Modificado por {item.UserId}, {DateTime.Now}." + JsonConvert.SerializeObject(entity) + "\n" + entity.Log;
            entity.Name = entityUpdate.Name;
            entity.Notes = entityUpdate.Notes;
            entity.Phone = entityUpdate.Phone;
            entity.ProjectId = entityUpdate.ProjectId;
            entity.Settlement = entityUpdate.Settlement;
            entity.State = entityUpdate.State;
            entity.TownHall = entityUpdate.TownHall;
            entity.ZipCode = entityUpdate.ZipCode;

            await _repository.Agency.UpdateAsync(entityUpdate);
        }
    }
}