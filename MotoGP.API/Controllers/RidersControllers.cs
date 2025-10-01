using Microsoft.AspNetCore.Mvc;
using MotoGP.API.Entities;
using MotoGP.API.Services;

namespace MotoGP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RidersController : ControllerBase
    {
        private readonly IRiderRepository _riderRepository;

        public RidersController(IRiderRepository riderRepository)
        {
            _riderRepository = riderRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rider>>> GetRiders()
        {
            var riders = await _riderRepository.GetRidersAsync();
            if (riders == null)
            {
                return NotFound();
            }
            return Ok(riders);
        }
    }
}





//using Microsoft.AspNetCore.Mvc;
//using MotoGP.Models;
//using MotoGP.API.DataStores;

//namespace MotoGP.API.Controllers
//{
//    public class RidersControllers
//    {
//        // Controllers/RidersController.cs
//        [ApiController]
//        [Route("api/[controller]")]
//        public class RidersController : ControllerBase
//        {
//            [HttpGet]
//            public ActionResult<IEnumerable<RiderDto>> GetRiders()
//            {
//                var riders = MotoGPDataStore.Instance.Teams
//                    .Where(t => t.Riders != null)
//                    .SelectMany(t => t.Riders!)
//                    .ToList();
//                return Ok(riders);
//            }

//            [HttpGet("{teamId}")]
//            public ActionResult<IEnumerable<RiderDto>> GetRiders(int teamId)
//            {
//                var team = MotoGPDataStore.Instance.Teams.FirstOrDefault(t => t.Id == teamId);
//                if (team == null)
//                {
//                    return NotFound();
//                }

//                return Ok(team.Riders);
//            }

//            [HttpGet("{teamId}/{riderId}")]
//            public ActionResult<RiderDto> GetRider(int teamId, int riderId)
//            {
//                var team = MotoGPDataStore.Instance.Teams.FirstOrDefault(t => t.Id == teamId);
//                if (team == null)
//                {
//                    return NotFound();
//                }

//                var riders = team.Riders;
//                if (riders == null)
//                {
//                    return NotFound();
//                }

//                var rider = riders.FirstOrDefault(r => r.Id == riderId);
//                if (rider == null)
//                {
//                    return NotFound();
//                }

//                return Ok(rider);
//            }

//        }


//    }
//}
