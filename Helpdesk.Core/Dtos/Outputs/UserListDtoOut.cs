using System.ComponentModel.DataAnnotations;

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