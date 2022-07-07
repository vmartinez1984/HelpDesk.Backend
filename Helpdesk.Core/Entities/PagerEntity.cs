using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk.Core.Entities
{
    public class PagerEntity
    {
        public int PageCurrent { get; set; }

        public int RecordsPerPage { get; set; }

        public int TotalRecords { get; set; }
    }
}