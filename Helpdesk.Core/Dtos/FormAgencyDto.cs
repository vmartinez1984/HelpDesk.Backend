using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Dtos
{
    public class FormAgencyDtoIn
    {
        public int AgencyId { get; set; }

        [Required(ErrorMessage = "El tipo de agencia es obligatorio")]
        [Display(Name = "Tipo")]
        public int AgencyTypeId { get; set; }

        [Required(ErrorMessage = "El proyecto es obligatorio")]
        [Display(Name = "Proyecto")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "La clave de agencia es obligatoria")]
        [StringLength(10)]
        [Display(Name = "Clave de agencia")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(255)]
        [MinLength(5)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        public int UserId { get; set; }

        [StringLength(2000)]
        [Display(Name = "Notas")]
        public string Notes { get; set; }

        public string Log { get; set; }

        [StringLength(255)]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        [Display(Name = "Correo")]
        public string email { get; set; }

        [Display(Name = "Texto de responsiva")]
        [StringLength(2000)]
        public string TextResponsive { get; set; }

        public List<int> ListDeviceIds { get; set; }
    }

    public class FormAgencyDto : FormAgencyDtoIn
    {
        public string Id { get; set; }
    }
}