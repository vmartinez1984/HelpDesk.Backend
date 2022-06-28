using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helpdesk.Core.Entities;

namespace Helpdesk.Core.Interfaces.IServices
{
    public interface IZipCodeService
    {
        Task<List<ZipCodeEntity>> GetAsync(string zipCode);
    }
}