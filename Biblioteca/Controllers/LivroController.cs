using AutoMapper;
using Biblioteca.Api.ViewModel;
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
    public class LivroController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILivroService _livroService;
        private readonly IMapper _mapper;
        public LivroController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper,
            ILivroService livroService)
        {
            _userManager = userManager;
            _livroService = livroService;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AdicionarLivro([FromBody]LivroViewModel livro)
        {
            try
            {
                return Ok(await _livroService.LivroPost(_mapper.Map<LivroPostDTO>(livro)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }

        [HttpGet]
        [Route("")]
        public IActionResult ObterTodosPaginado(int pagina, int qtdRegistros)
        {
            try
            {
                return Ok(_livroService.ObterTodos(pagina, qtdRegistros));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
