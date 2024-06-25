namespace Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public DateOnly Date { get; set; }
        public string Destiny { get; set; }
        public string Exit { get; set; }
        public int RouteId { get; set; }
        public Route route { get; set; }
    }
}
