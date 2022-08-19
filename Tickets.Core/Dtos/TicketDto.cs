using System.ComponentModel.DataAnnotations;

namespace Tickets.Core.Dtos
{
    public class TicketDtoIn
    {
        [Required(ErrorMessage = "Anote tag(s)")]
        public string Tags { get; set; }

        [Required(ErrorMessage = "Seleccione agencia")]
        [Display(Name = "Agencia")]
        public int AgencyId { get; set; }

        public string AgencyName { get; set; }

        [Required(ErrorMessage = "Seleccione persona")]
        [Display(Name = "Persona")]
        public int PersonId { get; set; }

        public string PersonName { get; set; }

        [Required(ErrorMessage = "Seleccione la categoria")]
        [Display(Name = "Categoria")]
        public string CategoryId { get; set; }

        [Required(ErrorMessage = "Seleccione la subcategoria")]
        [Display(Name = "Subcategoria")]
        public string SubcategoryId { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string State { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Tipo { get; set; }

        [Required(ErrorMessage = "Anote la descripción")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Solución")]
        public string Solution { get; set; }
    }

    public class TicketDto : TicketDtoIn
    {
        public string Id { get; set; }

        public string Category { get; set; }

        public string Subcategory { get; set; }

        public string DescriptionShort
        {
            get
            {
                string content;

                content = this.ListLog[0].Content;
                content = content.Length >= 25 ? content.Substring(0, 25) : content;
                return $"{content}...";
            }
        }

        public List<LogDto> ListLog { get; set; }
    }

    public class LogDto
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public string UserName { get; set; }

        public DateTime DateRegistration { get; set; }

        public string State { get; set; }
    }
}