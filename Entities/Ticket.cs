using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }

        [NotMapped]
        public DateOnly Date { get; set; }

        public string? Exit { get; set; }
        public string? Destiny { get; set; }
        public int RouteId { get; set; }
        public Route? Route { get; set; }

        public DateTime DateBackingField { get; set; }

        public Ticket()
        {
            Date = DateOnly.FromDateTime(DateBackingField);
        }
    }
}
