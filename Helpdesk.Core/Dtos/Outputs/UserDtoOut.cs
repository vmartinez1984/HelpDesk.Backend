namespace Helpdesk.Core.Dtos.Outputs
{
    public class UserDtoOut
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }

        public DateTime DateRegistration { get; set; }

        public int PersonId { get; set; }
    }
}
