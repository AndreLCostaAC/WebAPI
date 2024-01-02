using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller

    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);   

        }
    }
}
