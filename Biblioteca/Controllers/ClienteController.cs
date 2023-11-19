using AutoMapper;
using Biblioteca.Application.DTO;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities.ApplicationUsers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        public ClienteController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper,
            IClienteService clienteService)
        {
            _userManager = userManager;
            _clienteService = clienteService;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public IActionResult AdicionarCliente([FromBody] ClienteDTO dto)
        {
            try
            {
                return Ok(_clienteService.ClientePost(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult ObterClientePorId(long id)
        {
            try
            {
                return Ok(_clienteService.ClienteGetAById(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarCliente(long id)
        {
            try
            {
                return Ok(_clienteService.ClienteDelete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("")]
        public IActionResult AlterarCliente([FromBody] ClienteDTO dto)
        {
            try
            {
                return Ok(_clienteService.ClientePut(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
