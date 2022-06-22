using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Dtos.Inputs
{
    public class AgencyDtoIn
    {
        [Required]
        public int AgencyTypeId { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(255)]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Required]
        [StringLength(50)]
        public string TownHall { get; set; }

        [Required]
        [StringLength(120)]
        public string Settlement { get; set; }

        [Required]
        [StringLength(5)]
        public string ZipCode { get; set; }

        [Required]
        public int UserId { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        public string Log { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string email;
    }
}