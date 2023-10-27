using GestionEvent_DAL.Model;
using GestionEvent_DAL.Services.participate;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet]
  
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetByEvent(int id)
        {
            try
            {
                return Ok(_participateService.GetByEvent(id));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ParticipateController>
        [Authorize("IsConnected")]
        [HttpPost]
        public IActionResult AddParticipate([FromBody] Participate par)
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
