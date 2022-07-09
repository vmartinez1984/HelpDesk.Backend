namespace Helpdesk.Core.Dtos.Outputs
{
    public class UserDtoOut : PersonDtoOut
    {
        public string Email { get; set; }

        public string Password { get; set; }        

        public int PersonId { get; set; }
    }
}
