using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Route
    {
        public int RouteId { get; set; }
        public float Price { get; set; }
        public string? DestinyPlace { get; set; }
        public string? ExitPlace { get; set; }
        public List<Ticket>? Tickets { get; set; }
    }
}
