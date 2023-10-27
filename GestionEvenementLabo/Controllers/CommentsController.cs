using GestionEvent_DAL.Model;
using GestionEvent_DAL.Services.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionEvenementLabo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentService _commentService;
        public CommentsController( CommentService comm) { 
            _commentService = comm;
        }

        // GET: api/<CommentsController>
        [HttpGet]
        public IActionResult GetALL()
        {
            try
            {
                return Ok(_commentService.GetAll());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet("event/{id}")]
        public IActionResult GetByEvent(int id)
        {
            try
            {
                return Ok(_commentService.getByEvent(id));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_commentService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST api/<CommentsController>
        [Authorize]
        [HttpPost]
        public IActionResult AddComment([FromBody] Comments comment)
        {
            try
            {
                bool sucess = _commentService.AddComment(comment);
                if (!sucess)
                {
                    return BadRequest(sucess);
                }
                return Ok(sucess);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


       
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                bool success = _commentService.Delete(id);
                if (!success)
                {
                    return BadRequest("something wrong");
                }
                return Ok("commentaire supprimé");
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
