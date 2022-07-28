using System.ComponentModel.DataAnnotations;
using Helpdesk.Core.Dtos.Outputs;

namespace Helpdesk.Core.Dtos
{
    public class DeviceDtoIn
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Número de serie")]
        public string SerialNumber { get; set; }

        [Display(Name = "Fecha de inicio")]
        [DataType(DataType.Date)]
        public DateTime? DateStart { get; set; }

        [Display(Name = "Fecha fin")]
        [DataType(DataType.Date)]
        public DateTime? DateEnd { get; set; }

        [Display(Name = "Notas")]
        [StringLength(1000)]
        public string Notes { get; set; }

        [Display(Name = "Estado")]
        [Required]
        public int DeviceStateId { get; set; }
        public int UserId { get; set; }
    }

    public class DeviceDto : DeviceDtoIn
    {
        public int Id { get; set; }       

        [Display(Name = "Estado")]
        public string DeviceStateName { get; set; }
    }

    public class DeviceSearchDtoIn : PagerDto
    {
        [Display(Name = "Proyecto")]
        public int? ProjectId { get; set; }

        [Display(Name = "Agencia")]
        public int? AgencyId { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Número de serial")]
        public string SerialNumber { get; set; }
    }

    public class DeviceListDto : DeviceSearchDtoIn
    {
        public List<DeviceDto> ListDevices { get; set; }
    }
}