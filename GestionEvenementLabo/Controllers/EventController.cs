﻿using GestionEvent_DAL;
using GestionEvent_DAL.Services.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionEvenementLabo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventService _eventService;
        public EventController(EventService eventService) { 
            _eventService = eventService;
        }
        // GET: api/<EventController>


        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_eventService.GetAll());
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           return Ok (_eventService.GetById(id));
        }
       
        [HttpPost]
        public IActionResult AddEvent([FromBody] GestionEvent_DAL.Model.Event ev )
        {
            try
            {
               bool success =  _eventService.AddEvent(ev);
                if (!success)
                {
                    return BadRequest(success);
                }
                return Ok(success);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        // DELETE api/<EventController>/5
        [Authorize("ModoPolicy")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool success = _eventService.Delete(id);
                if (!success)
                {
                    return BadRequest(success);
                }
                return Ok(success);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
