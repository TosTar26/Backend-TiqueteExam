
using Entities;

namespace Services
{
    public interface ISvTicket
    {
        public List<Ticket> ReserveTicket(DateOnly date, string exit, string destiny);
        public float GetPrice(string exit, string destiny);
    }
}
