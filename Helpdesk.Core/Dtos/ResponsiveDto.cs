using System.ComponentModel.DataAnnotations;
using Helpdesk.Core.Dtos.Outputs;

namespace Helpdesk.Core.Dtos
{
    public class ResponsiveDto
    {
        public int Id { get; set; }

        public int AgencyId { get; set; }

        public string DocumentId { get; set; }

        public DateTime? DateSend { get; set; }

        [Display(Name = "Correo")]
        public string Email { get; set; }

        public ProjectDtoOut Project { get; set; }

        public AgencyDtoOut Agency { get; set; }

        [Display(Name = "Fecha")]
        public DateTime DateRegistration { get; set; }
    }

    public class ResponsivePagerDtoOut
    {
        public object TotalRecordsFiltered { get; set; }
        public object TotalRecords { get; set; }
        public List<ResponsiveDto> ListResponsive { get; set; }
    }
}