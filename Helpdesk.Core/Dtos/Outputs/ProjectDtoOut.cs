using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk.Core.Dtos.Outputs
{
    public class ProjectDtoOut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime DateRegistration { get; set; }
        public int UserId { get; set; }
    }
}