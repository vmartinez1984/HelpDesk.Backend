using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk.Core.Entities
{
    public class ProjectEntity : BaseEntity
    {
        [StringLength(1000)]
        public string Notes { get; set; }

        public int UserId { get; set; }
    }
}