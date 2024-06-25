using Entities;
using Microsoft.EntityFrameworkCore;
using Services.MyDbContext;

namespace Services
{
    public class SvTicket : ISvTicket
    {
        private readonly MyContext _context;

        public SvTicket(MyContext context)
        {
            _context = context;
        }

        public List<Ticket> ReserveTicket(DateOnly date, string exit, string destiny)
        {
            DateTime dateConverted = new DateTime(date.Year, date.Month, date.Day);

            int existingTicketsCount = _context.Tickets
                .Count(t => t.DateBackingField == dateConverted && t.Exit == exit && t.Destiny == destiny);

            if (existingTicketsCount >= 10)
            {
                throw new Exception("No se pueden reservar más de 10 tickets para la misma fecha, salida y destino.");
            }

            var route = _context.Routes
                .FirstOrDefault(r => r.ExitName == exit && r.DestinyName == destiny);

            if (route == null)
            {
                throw new Exception("No se encontró la ruta especificada.");
            }

            var ticket = new Ticket
            {
                DateBackingField = dateConverted,
                Exit = exit,
                Destiny = destiny,
                RouteId = route.RouteId,
                Route = route
            };

            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return _context.Tickets
                .Include(t => t.Route)
                .Where(t => t.DateBackingField == dateConverted && t.Exit == exit && t.Destiny == destiny)
                .ToList();
        }

        public float GetPrice(string exit, string destiny)
        {
            if (exit == destiny)
            {
                return 0;
            }

            var route = _context.Routes.FirstOrDefault(r => r.ExitName == exit && r.DestinyName == destiny);
            if (route == null)
            {
                throw new Exception("Route not found.");
            }

            return (float)route.Price;
        }

    }
}
