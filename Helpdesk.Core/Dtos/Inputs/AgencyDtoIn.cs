using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk.Core.Dtos.Inputs
{
    public class AgencyDtoIn
    {       
        public int AgencyTypeId { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string TownHall { get; set; }

        [StringLength(120)]
        public string Settlement { get; set; }

        [StringLength(5)]
        public string ZipCode { get; set; }
        
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