using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk.Core.Interfaces.InterfaceBl
{
    public interface IBaseBl
    {
        Task<int> AddAsync(T item);
        Task DeleteAsync(int id);
        Task<U> GetAsync(int id);
        Task<List<U>> GetAsync();
        Task UpdateAsync(T item, int id);
    }

    public interface IUser: IBaseBl{}
}