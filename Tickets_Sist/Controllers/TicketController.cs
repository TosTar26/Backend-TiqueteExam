using Microsoft.AspNetCore.Mvc;
using Services;
using DTOS;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ISvTicket _svTicket;

        public TicketController(ISvTicket svTicket)
        {
            _svTicket = svTicket;
        }

        [HttpPost("reserve")]
        public IActionResult ReserveTicket([FromBody] TicketDTO ticketDTO)
        {
            try
            {
                var tickets = _svTicket.ReserveTicket(ticketDTO.Date, ticketDTO.Exit, ticketDTO.Destiny);
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getPrice")]
        public IActionResult GetPrice([FromQuery] string exit, [FromQuery] string destiny)
        {
            try
            {
                var price = _svTicket.GetPrice(exit, destiny);
                return Ok(price);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
