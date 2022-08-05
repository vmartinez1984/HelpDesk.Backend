using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Dtos.Outputs
{
    public class AgencyTypeDtoOut
    {
        public int Id { get; set; }

        [Display(Name = "Tipo")]
        public string Name { get; set; }
    }
}