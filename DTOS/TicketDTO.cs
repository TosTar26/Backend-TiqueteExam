using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS
{
    public class TicketDTO
    {
        public DateOnly Date { get; set; }
        public string? Exit { get; set; }
        public string? Destiny { get; set; }
    }
}
