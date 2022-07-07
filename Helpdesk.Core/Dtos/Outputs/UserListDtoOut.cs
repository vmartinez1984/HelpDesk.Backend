using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk.Core.Dtos.Outputs
{
    public class UserListDtoOut
    {
        [Display(Name = "Proyecto")]
        public int ProjectId { get; set; }

        [Display(Name = "Agencia")]
        public int AgencyId { get; set; }

        [Display(Name = "Nombre")]
        public string UserName { get; set; }
        public List<UserDtoOut> ListUsers { get; set; }
    }
}