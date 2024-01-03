using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Identity.Client;
using WebAPI.DTO;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Client>))]

        public IActionResult GetClients()
        {

            var clients = _mapper.Map<List<ClientDto>>(_clientRepository.GetClients());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(clients);
        }

        [HttpGet("{clientId}")]
        [ProducesResponseType(200, Type = typeof(Client))]
        [ProducesResponseType(400)]

        public IActionResult GetClient(int clientId)
        {
            if (!_clientRepository.ClientExists(clientId))
            {
                return NotFound();
            }
            var client = _clientRepository.GetClient(clientId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(client);
        }

        [HttpGet("packagehours/{clientId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]

        public IActionResult HasPackageHours(int clientId)
        {
            if (!_clientRepository.ClientExists(clientId))
            {
                return NotFound();
            }
            var client = _clientRepository.HasClientHoursPackage(clientId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(client);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateClient([FromBody] ClientDto clientCreate)
        {
            if (clientCreate == null)
                return BadRequest(ModelState);

            var client = _clientRepository.GetClients()
                .Where(c => c.Name == clientCreate.Company)
                .FirstOrDefault();

            if (client != null)
            {
                ModelState.AddModelError("", "Client alredy exists");
                return StatusCode(StatusCodes.Status422UnprocessableEntity);
                //return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientMap = _mapper.Map<Client>(clientCreate);

            if (!_clientRepository.CreateClient(clientMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
            
        }

        [HttpPut("{clientId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateClient(int clientId, [FromBody]ClientDto clientUpdate)
        {

            var clienteUpdate = _clientRepository.GetClient(clientId);


            if (clientUpdate == null)
                return BadRequest(ModelState);

            if (clientId != clientUpdate.Id)
                return BadRequest(ModelState);

            if (!_clientRepository.ClientExists(clientId))
                return NotFound();

            if(!ModelState.IsValid)
                return BadRequest();

            var clientMap = _mapper.Map<Client>(clienteUpdate);

            if (!_clientRepository.UpdateClient(clientMap))
            {
                ModelState.AddModelError("", "Something went wrong updating client");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete("{clientId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteClient(int clientId)
        {
           
            if (!_clientRepository.ClientExists(clientId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var clientToDelete = _clientRepository.GetClient(clientId);


            if (!_clientRepository.DeleteClient(clientToDelete))
            {
                ModelState.AddModelError("", "Something went wrong updating client");
                return StatusCode(500, ModelState);
            }
            
            return NoContent();

        }



    }


}
