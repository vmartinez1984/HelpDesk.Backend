using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Dtos.Inputs
{
    public class ProjectDtoIn
    {
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        public int UserId { get; set; }
    }
}