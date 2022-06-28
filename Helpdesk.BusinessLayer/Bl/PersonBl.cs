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

        public Task<List<PersonDtoOut>> GetAsync(int? projectId, int? agencyId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PersonDtoIn item, int id)
        {
            throw new NotImplementedException();
        }

        Task<PagerGenericDtoIn<PersonDtoOut>> IPersonBl.GetAsync(int? projectId, int? agencyId)
        {
            throw new NotImplementedException();
        }
    }
}