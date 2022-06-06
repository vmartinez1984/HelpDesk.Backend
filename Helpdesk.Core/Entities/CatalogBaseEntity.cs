using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk.Core.Entities
{
    public class CatalogBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class BaseEntity : CatalogoEntity
    {

        public DateTime DateRegister { get; set; }
        public bool IsActive { get; set; }
    }
}