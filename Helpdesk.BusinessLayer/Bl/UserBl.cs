using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Interfaces.InterfaceBl;

namespace Helpdesk.BusinessLayer.Bl
{
    public class UserBl : IUser
    {
        public Task<int> AddAsync(UserDtoIn item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDtoOut> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDtoOut>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserDtoIn item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
