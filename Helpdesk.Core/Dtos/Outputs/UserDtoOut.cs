using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Nombre")]
        public string FullName { get { return this.Name + " " + this.LastName; } }
    }

    public class UserDto
    {
        public int Id { get; set; }
        
        public PersonDtoOut Person { get; set; }

        public string Email { get; set; }

        public int PersonId { get; set; }

        public int RoleId { get; set; }

        [Display(Name = "Nombre")]
        public string FullName { get { return this.Person.Name + " " + this.Person.LastName; } }
    }
}
