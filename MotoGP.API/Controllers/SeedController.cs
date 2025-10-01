using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotoGP.API.DBContext;
using MotoGP.API.Seeders;

namespace MotoGP.API.Controllers
{
    [Route("api/seed")]
    [ApiController]
    public class SeedController : ControllerBase
    {

        private readonly MotoGPContext _context;

        public SeedController(MotoGPContext context)
        {
            _context = context;
        }

        [HttpPost("tickets")]
        public async Task<IActionResult> SeedTickets()
        {
            var seeder = new TicketSeeder(_context);
            var tickets = await seeder.GenerateTicketsAsync(1000);

            _context.Tickets.AddRange(tickets);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Tickets seeded successfully!", count = tickets.Count });
        }
      
      
     }
    
}
