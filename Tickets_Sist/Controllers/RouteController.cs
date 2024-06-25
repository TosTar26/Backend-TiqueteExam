using Microsoft.AspNetCore.Mvc;
using Services.Route;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouteController : ControllerBase
    {
        private readonly ISvRoute _svRoute;

        public RouteController(ISvRoute svRoute)
        {
            _svRoute = svRoute;
        }

        [HttpGet("countPassengers")]
        public IActionResult CountPassengers([FromQuery] string exit, [FromQuery] string destiny)
        {
            try
            {
                var count = _svRoute.CountPassengers(exit, destiny);
                return Ok(count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("countPassengersByDateRange")]
        public IActionResult CountPassengersByDateRange([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            try
            {
                var count = _svRoute.CountPassengersByDateRange(fechaInicio, fechaFin);
                return Ok(count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("total-revenue")]
        public IActionResult GetTotalRevenue(string exit, string destiny)
        {
            try
            {
                float totalRevenue = (float)_svRoute.TotalRevenueByRoute(exit, destiny);
                return Ok(totalRevenue);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("total-revenue-by-date-range")]
        public IActionResult GetTotalRevenueByDateRange(DateOnly fechaInicio, DateOnly fechaFin)
        {
            try
            {
                float totalRevenue = _svRoute.TotalRevenueByDateRange(fechaInicio, fechaFin);
                return Ok(totalRevenue);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
