namespace Helpdesk.Core.Dtos.Outputs
{
    public class PersonPagerDtoOut
    {
        public PersonSearchDto PersonSearch { get; set; }
        
        public List<PersonDtoOut> ListPersons { get; set; }

        public PagerDto Pager { get; set; }
    }
}