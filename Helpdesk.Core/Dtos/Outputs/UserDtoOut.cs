using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
