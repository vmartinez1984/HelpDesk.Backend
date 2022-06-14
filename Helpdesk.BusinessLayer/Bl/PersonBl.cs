using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Interfaces.InterfaceBl;

namespace Helpdesk.BusinessLayer.Bl
{
    public class PersonBl : IPersonBl
    {
        public Task<int> AddAsync(PersonDtoIn item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDtoOut> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonDtoOut>> GetListByAgencyIdAsync(int agencyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonDtoOut>> GetListByProjectIdAsync(int projectId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PersonDtoIn item, int id)
        {
            throw new NotImplementedException();
        }
    }
}