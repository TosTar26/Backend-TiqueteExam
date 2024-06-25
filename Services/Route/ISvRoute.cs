

namespace Services.Route
{
    public interface ISvRoute
    {
     public int CountPassengers(string exit, string destiny);
     public int CountPassengersByDateRange(DateTime fechaInicio, DateTime fechaFin);
     public float TotalRevenueByRoute(string exit, string destiny);
     public float TotalRevenueByDateRange(DateOnly fechaInicio, DateOnly fechaFin);
    }
}
