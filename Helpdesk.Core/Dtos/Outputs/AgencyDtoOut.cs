using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Dtos.Outputs
{
    public class AgencyDtoOut
    {
        public int Id { get; set; }
        
        public int AgencyTypeId { get; set; }

        [Display(Name = "Tipo")]
        public string? AgencyTypeName { get; set; }

        [Display(Name = "Clave")]
        public string? Code { get; set; }

        [Display(Name = "Nombre")]
        public string? Name { get; set; }

        [Display(Name = "Dirección")]
        public string? Address { get; set; }

        [Display(Name = "Estado")]
        public string? State { get; set; }

        [Display(Name = "Alcaldia")]
        public string? TownHall { get; set; }

        [Display(Name = "Colonia")]
        public string? Settlement { get; set; }

        [Display(Name = "Código postal")]
        public string? ZipCode { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Notas")]
        public string? Notes { get; set; }

        public string? Log { get; set; }

        [Display(Name = "Telefono")]
        public string? Phone { get; set; }

        [Display(Name = "correo")]
        public string? email;

        [Display(Name = "Fecha de registro")]
        [DataType(DataType.Date)]
        public DateTime DateRegistration { get; set; }
    }
}