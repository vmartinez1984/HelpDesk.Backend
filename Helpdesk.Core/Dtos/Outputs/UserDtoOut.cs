using Helpdesk.Core.Validators;

namespace Helpdesk.Core.Dtos.Outputs
{
    public class UserDtoOut : PersonDtoOut
    {
        [EmailExists]
        public string Email { get; set; }

        public string Password { get; set; }        

        public int PersonId { get; set; }

        public int RoleId { get; set; }
    }
}
