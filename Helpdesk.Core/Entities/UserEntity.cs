using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpdesk.core.entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}