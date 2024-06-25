using Services.MyDbContext;
using Services.Route;

namespace Services
{
    public class SvRoute : ISvRoute
    {
        private readonly MyContext _context;

        public SvRoute(MyContext context)
        {
            _context = context;
        }

        public int CountPassengers(string exit, string destiny)
        {
            return _context.Tickets
                .Count(t => t.Exit == exit && t.Destiny == destiny);
        }

        public int CountPassengersByDateRange(DateTime fechaInicio, DateTime fechaFin)
        {
            return _context.Tickets
                .Count(t => t.DateBackingField >= fechaInicio && t.DateBackingField <= fechaFin);
        }

        public float TotalRevenueByRoute(string exit, string destiny)
        {
            // Obtener la ruta específica
            var route = _context.Routes
                .FirstOrDefault(r => r.ExitName == exit && r.DestinyName == destiny);

            if (route == null)
            {
                throw new Exception("Route not found.");
            }

            // Calcular el total de dinero recolectado
            float totalRevenue = (float)_context.Tickets
                .Where(t => t.Exit == exit && t.Destiny == destiny)
                .Sum(t => t.Route.Price);

            return totalRevenue;
        }

        public float TotalRevenueByDateRange(DateOnly fechaInicio, DateOnly fechaFin)
        {
            DateTime dateInicio = new DateTime(fechaInicio.Year, fechaInicio.Month, fechaInicio.Day);
            DateTime dateFin = new DateTime(fechaFin.Year, fechaFin.Month, fechaFin.Day).AddDays(1).AddTicks(-1);

            float totalRevenue = _context.Tickets
                .Where(t => t.DateBackingField >= dateInicio && t.DateBackingField <= dateFin)
                .Sum(t => (float)t.Route.Price);

            return totalRevenue;
        }

    }
}
