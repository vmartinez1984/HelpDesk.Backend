using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk.Core.Dtos.Inputs
{
    public class PersonSearchDtonIn
    {
        public int? ProjectId { get; set; }

        public int? AgencyId { get; set; }

        public string? PersonName { get; set; }

        public string? PersonLastName { get; set; }
    }
}