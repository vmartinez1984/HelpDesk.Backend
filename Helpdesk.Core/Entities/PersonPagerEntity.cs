namespace Helpdesk.Core.Entities
{
    public class PersonPagerEntity
    {
        public PersonSearchEntity PersonSearch { get; set; }
        public List<PersonEntity> ListPersons { get; set; }
    }
}