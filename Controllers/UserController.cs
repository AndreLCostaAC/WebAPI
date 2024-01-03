using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller

    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
            
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        
        public IActionResult GetUsers()
        {
            //Introced autommaper -> _mapper.Map<List<UserDto>> so it don t appear nulls
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);   

        }

        // the route needs to be exatly as the argument of the method
        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]

        public IActionResult GetUser(int userId)
        {
            if (!_userRepository.UserExists(userId))
                return NotFound();

            var user = _mapper.Map<User>(_userRepository.GetUser(userId));
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateUser([FromBody] UserDto userCreate)
        {
            if (userCreate == null)
                return BadRequest(ModelState);

            var ticketName = _userRepository.GetUsers()
                .Where(c => c.Name.Trim().ToLower() == userCreate.Name.TrimEnd().ToLower())
                .FirstOrDefault();

            if (ticketName != null)
            {
                ModelState.AddModelError("", "Ticket alredy exists");
                return StatusCode(StatusCodes.Status422UnprocessableEntity);
                //return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userMap = _mapper.Map<User>(userCreate);

            if (!_userRepository.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

    }
}
