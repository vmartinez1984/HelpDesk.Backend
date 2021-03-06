using AutoMapper;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Core.Interfaces.IRepositories;

namespace Helpdesk.BusinessLayer.Bl
{
    public class RoleBl : IRoleBl
    {
        private IRepository _repository;
        private IMapper _mapper;

        public RoleBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<RoleDto>> GetAsync()
        {
            List<RoleDto> list;
            List<RoleEntity> entities;

            entities = await _repository.Role.GetAsync();
            list = _mapper.Map<List<RoleDto>>(entities);

            return list;
        }
    }
}