using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk.Core.Dtos.Outputs
{
    public class PersonSearchDto : SearchDto
    {
        [Display(Name = "Proyecto")]
        public int ProjectId { get; set; }

        [Display(Name = "Agencia")]
        public int AgencyId { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(150)]
        public string LastName { get; set; }
    }
}