namespace Helpdesk.Core.Dtos.Inputs
{
    public class PersonSearchDtoIn : SearchDto
    {
        public int ProjectId { get; set; }

        public int AgencyId { get; set; }
    }
}