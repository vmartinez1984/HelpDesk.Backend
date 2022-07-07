using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk.Core.Dtos.Outputs
{
    public class SearchDto
    {
        public int Page { get; set; }
		public int NumberOfRecordsPerPage { get; set; }
    }
}