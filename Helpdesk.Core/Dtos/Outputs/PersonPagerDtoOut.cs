namespace Helpdesk.Core.Dtos.Outputs
{
    public class PersonPagerDtoOut :PagerDto
    {
        public List<PersonDtoOut> ListPersons { get; set; }
    }
}