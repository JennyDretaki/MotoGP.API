//using AutoMapper;
//using Microsoft.AspNetCore.JsonPatch;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using MotoGP.API.DBContext;
//using MotoGP.API.Models;

//namespace MotoGP.API.Controllers
//{
//    [ApiController]
//    [Route("api/tickets")]
//    public class TicketsController : ControllerBase
//    {
//        private readonly MotoGPContext _context;
//        private readonly IMapper _mapper;

//        public TicketsController(MotoGPContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public ActionResult<IEnumerable<TicketListDto>> GetTickets()
//        {
//            var tickets = _context.Tickets
//                .Include(t => t.Country)
//                .Include(t => t.Race)
//                .OrderBy(t => t.OrderDate)
//                .ToListAsync();
//            if (tickets == null)
//                return NotFound();

//            return Ok(_mapper.Map<IEnumerable<TicketListDto>>(tickets));
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<TicketDetailsDto>> GetTicket(int id)
//        {
//            var ticket = await _context.Tickets
//                .Include(t => t.Country)
//                .Include(t => t.Race)
//                .FirstOrDefaultAsync(t => t.Id == id);

//            if (ticket == null)
//                return NotFound();

//            return Ok(_mapper.Map<TicketDetailsDto>(ticket));
//        }


//        //[HttpPost]
//        //public async Task<ActionResult<TicketListDto>> CreateTicket(TicketForCreationDto dto)
//        //{
//        //    if (!await _context.Countries.AnyAsync(c => c.Id == dto.CountryId))
//        //        return BadRequest($"Country with Id {dto.CountryId} does not exist.");

//        //    if (!await _context.Races.AnyAsync(r => r.Id == dto.RaceId))
//        //        return BadRequest($"Race with Id {dto.RaceId} does not exist.");

//        //    var ticket = _mapper.Map<Ticket>(dto);
//        //    _context.Tickets.Add(ticket);
//        //    await _context.SaveChangesAsync();

//        //    return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, _mapper.Map<TicketListDto>(ticket));
//        //}
//        [HttpPost]
//        public ActionResult<TicketListDto> CreateTicket(TicketForCreationDto ticket)
//        {
//            var ticketEntity = _mapper.Map<Ticket>(ticket);

//            _context.Tickets.Add(ticketEntity);
//            _context.SaveChanges();

//            var createdTicketToReturn = _mapper.Map<TicketListDto>(ticketEntity);

//            return CreatedAtAction(nameof(GetTicket),
//                new
//                {
//                    id = createdTicketToReturn.Id
//                },
//                createdTicketToReturn);
//        }

//        [HttpPatch("{ticketId}")]
//        public ActionResult PartiallyUpdateTicket(int ticketId,
//                    JsonPatchDocument<TicketForUpdateDto> patchDocument)//we wrap the Dto in a Patch document
//        {
//            var ticketEntity = _context.Tickets.Find(ticketId);
//            if (ticketEntity == null)
//            {
//                return NotFound();
//            }

//            // Map entity to update DTO
//            var ticketToPatch = _mapper.Map<TicketForUpdateDto>(ticketEntity);

//            // Validation
//            patchDocument.ApplyTo(ticketToPatch, ModelState);

//            // Patch is done, check validity and correspond accordingly
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }


//            if (!TryValidateModel(ticketToPatch))
//            {
//                return BadRequest(ModelState);
//            }

//            // DTO is valid --> map back to entity and save changes
//            _mapper.Map(ticketToPatch, ticketEntity);

//            // Persist changes to database
//            _context.SaveChanges();

//            return NoContent();
//        }



//    }

//}


using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MotoGP.API.Services;
using MotoGP.API.Entities;
using MotoGP.API.Models;

namespace MotoGP.API.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IRaceRepository _raceRepository;
        private readonly IMapper _mapper;

        public TicketsController(ITicketRepository ticketRepository, ICountryRepository countryRepository, IRaceRepository raceRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _countryRepository = countryRepository;
            _raceRepository = raceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketListDto>>> GetTickets(
            [FromQuery] string? searchQuery,
            [FromQuery] int? countryId,
            [FromQuery] int? raceId,
            [FromQuery] bool? open,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var tickets = await _ticketRepository.GetTicketsAsync(searchQuery, countryId, raceId, open);
            var paginationMetadata = new
            {
                totalCount = tickets.Count(),
                pageSize,
                currentPage = pageNumber,
                totalPages = (int)Math.Ceiling(tickets.Count() / (double)pageSize)
            };

            Response.Headers.Add("X-Pagination", System.Text.Json.JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<TicketListDto>>(tickets));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDetailsDto>> GetTicket(int id)
        {
            var ticket = await _ticketRepository.GetTicketAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TicketDetailsDto>(ticket));
        }

        [HttpPost]
        public async Task<ActionResult<TicketListDto>> CreateTicket(TicketForCreationDto ticket)
        {
            if (!await _countryRepository.CountryExistsAsync(ticket.CountryId))
            {
                return BadRequest($"Country with Id {ticket.CountryId} does not exist.");
            }

            if (!await _raceRepository.RaceExistsAsync(ticket.RaceId))
            {
                return BadRequest($"Race with Id {ticket.RaceId} does not exist.");
            }

            var ticketEntity = _mapper.Map<Ticket>(ticket);
            _ticketRepository.AddTicket(ticketEntity);
            await _ticketRepository.SaveChangesAsync();

            var createdTicketToReturn = _mapper.Map<TicketListDto>(ticketEntity);

            return CreatedAtAction(nameof(GetTicket),
                new
                {
                    id = createdTicketToReturn.Id
                },
                createdTicketToReturn);
        }

        [HttpPatch("{ticketId}")]
        public async Task<ActionResult> PartiallyUpdateTicket(int ticketId,
                    JsonPatchDocument<TicketForUpdateDto> patchDocument)
        {
            var ticketEntity = await _ticketRepository.GetTicketAsync(ticketId);
            if (ticketEntity == null)
            {
                return NotFound();
            }

            var ticketToPatch = _mapper.Map<TicketForUpdateDto>(ticketEntity);

            patchDocument.ApplyTo(ticketToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(ticketToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(ticketToPatch, ticketEntity);

            await _ticketRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}


