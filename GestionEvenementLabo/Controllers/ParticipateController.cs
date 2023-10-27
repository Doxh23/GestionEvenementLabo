using GestionEvent_DAL.Model;
using GestionEvent_DAL.Services.participate;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipateController : ControllerBase
    {
        private readonly ParticipateService _participateService;
        public ParticipateController(ParticipateService par)
        {
            _participateService = par;
        }
        // GET: api/<ParticipateController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ParticipateController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ParticipateController>
        [HttpPost]
        public IActionResult Post([FromBody] Participate par)
        {
            try
            {
                return Ok(_participateService.addParticipate(par));
            }catch (Exception ex) { 
            return BadRequest(ex.Message);
            }
        }

     
    }
}
