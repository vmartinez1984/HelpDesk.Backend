using AutoMapper;
using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Core.Interfaces.IRepositories;

namespace Helpdesk.BusinessLayer.Bl
{
    public class AgencyTypeBl : IAgencyTypeBl
    {
        private IRepository _repository;
        private IMapper _mapper;

        public AgencyTypeBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(AgencyTypeDtoIn item)
        {
            AgencyTypeEntity entity;

            entity = _mapper.Map<AgencyTypeEntity>(item);
            entity.Id = await _repository.AgencyType.AddAsync(entity);

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.AgencyType.DeleteAsync(id, 1);
        }

        public async Task<AgencyTypeDtoOut> GetAsync(int id)
        {
            AgencyTypeDtoOut item;
            AgencyTypeEntity entity;

            entity = await _repository.AgencyType.GetAsync(id);
            item = _mapper.Map<AgencyTypeDtoOut>(entity);

            return item;
        }

        public async Task<List<AgencyTypeDtoOut>> GetAsync()
        {
            List<AgencyTypeDtoOut> list;
            List<AgencyTypeEntity> entities;

            entities = await _repository.AgencyType.GetAsync();
            list = _mapper.Map<List<AgencyTypeDtoOut>>(entities);

            return list;
        }

        public async Task UpdateAsync(AgencyTypeDtoIn item, int id)
        {
            AgencyTypeEntity entity;

            entity = await _repository.AgencyType.GetAsync(id);
            entity.Name = item.Name;

            await _repository.AgencyType.UpdateAsync(entity);
        }
    }//end class
}