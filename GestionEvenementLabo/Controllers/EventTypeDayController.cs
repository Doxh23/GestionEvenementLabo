using GestionEvent_DAL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypeDayController : ControllerBase
    {

        private readonly EventTypeDayService _ets;

        public EventTypeDayController(EventTypeDayService ets)
        {
            _ets = ets;
        }
        // GET: api/<EventTypeDayController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_ets.GetAll());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<EventTypeDayController>/5
        [HttpGet("getByEvent/{id}")]
  
        public IActionResult getByEvent(int id)
        {
            try
            {
                return Ok(_ets.GetByEvent(id));
            }catch(Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        // POST api/<EventTypeDayController>
        [Authorize("ModoPolicy")]
        [HttpPost]
        public IActionResult addDays([FromBody] GestionEvent_DAL.Model.EventTypeDay etd)
        {
            try
            {
                bool success = _ets.AddDay(etd);
                if (success)
                {
                    return Ok(success);
                }
                else
                {
                    return BadRequest(success);
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
