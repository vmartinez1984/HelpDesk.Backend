using AutoMapper;
using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Core.Interfaces.IRepositories;

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

            return item;
        }

        public async Task<List<AgencyDtoOut>> GetListAsync(int projectId)
        {
            List<AgencyDtoOut> list;
            List<AgencyEntity> entities;

            entities = await _repository.Agency.GetListAsync(projectId);
            list = _mapper.Map<List<AgencyDtoOut>>(entities);

            return list;
        }

        public async Task UpdateAsync(AgencyDtoIn item, int id)
        {
            AgencyEntity entity;

            entity = await _repository.Agency.GetAsync(id);
            var entityActualizada = _mapper.Map<AgencyEntity>(item);
            entityActualizada.Id = id;
            entityActualizada.DateRegistration = entity.DateRegistration;
            entityActualizada.IsActive = entity.IsActive;

            await _repository.Agency.UpdateAsync(entityActualizada);
        }
    }
}