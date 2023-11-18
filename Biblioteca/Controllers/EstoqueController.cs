using AutoMapper;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities.ApplicationUsers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEstoqueService _estoqueService;
        private readonly IMapper _mapper;
        public EstoqueController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper,
            IEstoqueService estoqueService)
        {
            _userManager = userManager;
            _estoqueService = estoqueService;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public IActionResult PutEstoque(long livroId, long qtdInserida)
        {
            try
            {
                if (livroId == 0 || qtdInserida == 0)
                    throw new Exception("Todos parâmetros devem ser preenchidos");
                return Ok(_estoqueService.AlterarEstoque(livroId, qtdInserida));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
