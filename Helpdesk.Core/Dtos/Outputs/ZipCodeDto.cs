using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helpdesk.Core.Dtos.Outputs
{
    public class ZipCodeDto
    {
        public string? ZipCode { get; set; }
        public string? State { get; set; }
        public string? Municipality { get; set; }
        public string? SettementType { get; set; }
        public string? Settement { get; set; }
    }
}