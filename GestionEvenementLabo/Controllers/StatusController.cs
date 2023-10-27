using GestionEvent_DAL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        private readonly StatusService _StatusService;
        public StatusController(StatusService statusService)
        {
            _StatusService = statusService;
        }
        // GET: api/<StatusController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_StatusService.GetAll());
            }catch (Exception ex)
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
                return Ok(_StatusService.GetById(id));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST api/<StatusController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<StatusController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<StatusController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
