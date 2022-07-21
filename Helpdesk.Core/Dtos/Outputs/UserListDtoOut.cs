using System.ComponentModel.DataAnnotations;
using Helpdesk.Core.Dtos.Inputs;

namespace Helpdesk.Core.Dtos.Outputs
{
    public class UserListDtoOut : UserSearchDtoIn
    {       
        public List<UserDtoOut> ListUsers { get; set; }
    }
}