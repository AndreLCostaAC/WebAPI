using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class TicketsController : Controller
    {
        private readonly ITicketsRepository _ticketsController;
        private readonly IMapper _mapper;

        public TicketsController(ITicketsRepository ticketsController, IMapper mapper)
        {

            _ticketsController = ticketsController;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Country))]

        public IActionResult GetTickets()
        {
            var tickets = _mapper.Map<List<TicketsDto>>(_ticketsController.GetTickets());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tickets);
        }
        [HttpGet("{ticketId}")]
        [ProducesResponseType(200, Type = typeof(Tickets))]
        [ProducesResponseType(400)]

        public IActionResult GetTicketById(int ticketId)
        {
            if (!_ticketsController.TicketExists(ticketId))
            {
                return NotFound();
            }
            var ticket = _ticketsController.GetUserByTicketId(ticketId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(ticket);
        }

        [HttpGet("Tickets/{ticketId}")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]

        public IActionResult GetUserByTicketId(int ticketId)
        {
            if (!_ticketsController.TicketExists(ticketId))
            {
                return NotFound();
            }
            var descr = _ticketsController.GetUserByTicketId(ticketId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(descr);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateTicket([FromBody] TicketsDto ticketsCreate)
        {
            if (ticketsCreate == null)
                return BadRequest(ModelState);

            var ticket = _ticketsController.GetTickets()
                .Where(c => c.Name.Trim().ToLower() == ticketsCreate.Name.TrimEnd().ToLower())
                .FirstOrDefault();

            if (ticket != null)
            {
                ModelState.AddModelError("", "Ticket alredy exists");
                return StatusCode(StatusCodes.Status422UnprocessableEntity);
                //return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticketMap = _mapper.Map<Tickets>(ticketsCreate);

            if (!_ticketsController.CreateTicket(ticketMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }
    }
}
