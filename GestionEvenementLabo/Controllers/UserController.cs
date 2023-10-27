using GestionEvenementLabo.tools;
using GestionEvent_DAL.model;
using GestionEvent_DAL.Model;
using GestionEvent_DAL.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionEvenementLabo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UsersService _userService;
        private readonly TokenManager _tokenManager;
        public UserController(UsersService userService,TokenManager tk)
        {
            _userService = userService;
            _tokenManager = tk;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        //Post : Register
        [HttpPost("register")]
        public IActionResult Register(UserFormRegister user)
        {

            try
            {
                bool created = _userService.Register(user);

                if(created)
                {
                    return Ok(created);

                }
                else
                {
                    return BadRequest(StatusCode(500));
                }
            }catch (Exception ex)
            {
                return BadRequest($" could not register {ex.Message} ");
            }
         
            }
       

        [HttpPost("Login")]
        public IActionResult Login(UserFormLogin user)
        {
            User u = _userService.Login(user.Email,user.Password);
            if (u != null)
            {
              
                return Ok(_tokenManager.generateToken(u));
            }
            return BadRequest("mauvais identifiant");
        }
       
        [Authorize("ModoPolicy")]
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool created = _userService.Delete(id);

                if (created)
                {
                    return Ok("le compte a bien été supprimé");

                }
                else
                {
                    return BadRequest(StatusCode(500));
                }
            }
            catch (Exception ex)
            {
                return BadRequest($" could not register {ex.Message} ");
            }
        }
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            try
            {
                User u = _userService.GetById(id);
                if(u != null)
                {
                    return Ok(u);

                }
                else
                {
                    return BadRequest($"user non trouvée avec l'Id {id}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($" could not register {ex.Message} ");
            }
        }






    }
}
