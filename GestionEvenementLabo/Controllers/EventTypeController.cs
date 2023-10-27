using GestionEvent_DAL.Services;
using GestionEvent_DAL.Services.EventType;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly EventTypeService _eventTypeService;
        public EventTypeController(EventTypeService eventTypeService)
        {
            _eventTypeService = eventTypeService;
        }
        // GET: api/<EventTypeController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_eventTypeService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<StatusController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_eventTypeService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
