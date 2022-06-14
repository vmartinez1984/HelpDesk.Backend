using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk.Core.Dtos.Inputs
{
    public class AgencyTypeDtoIn
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}