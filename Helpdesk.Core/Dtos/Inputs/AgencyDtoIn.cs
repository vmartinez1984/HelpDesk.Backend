using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Dtos.Inputs
{
    public class AgencyDtoIn
    {
        [Required(ErrorMessage = "El tipo de agencia es obligatorio")]
        [Display(Name = "Tipo")]
        public int AgencyTypeId { get; set; }

        [Required(ErrorMessage = "El proyecto es obligatorio")]
        [Display(Name = "Proyecto")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "La clave de agencia es obligatoria")]
        [StringLength(10)]
        [Display(Name = "Clave de agencia")]
        public string? Code { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(255)]
        [MinLength(5)]
        [Display(Name = "Nombre")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(255)]
        [Display(Name = "Dirección")]
        public string? Address { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Estado")]
        public string? State { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Alcaldia")]
        public string? TownHall { get; set; }

        [Required(ErrorMessage = "Seleccione la colonia")]
        [StringLength(120)]
        [Display(Name = "Colonia")]
        public string? Settlement { get; set; }

        [Required(ErrorMessage = "El código postal es obligatorio")]
        [StringLength(5)]
        [Display(Name = "Código postal")]
        public string? ZipCode { get; set; }

        [Required]
        public int UserId { get; set; }

        [StringLength(1000)]
        [Display(Name = "Notas")]
        public string? Notes { get; set; }

        public string? Log { get; set; }

        [StringLength(255)]
        [Display(Name = "Teléfono")]
        public string? Phone { get; set; }

        [StringLength(255)]
        [Display(Name = "Correo")]
        public string? email;

    }//end class
}