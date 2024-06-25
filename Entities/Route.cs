namespace Entities
{
    public class Route
    {
        public int RouteId { get; set; }
        public float Price { get; set; }
        public string DestinyName { get; set; }
        public string ExitName { get; set; }
        public List<Ticket> Tickets { get; set; }
    } 
}
