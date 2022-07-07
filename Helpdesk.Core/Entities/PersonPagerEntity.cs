using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk.Core.Entities
{
    public class PersonPagerEntity
    {
        public PersonSearchEntity PersonSearch { get; set; }
        public List<PersonEntity> ListPersons { get; set; }
        public PagerEntity Pager { get; set; }
    }
}