using Drogaria.Api.Token;
using Drogaria.Api.ViewModel;
using Drogaria.Domain.Entities.ApplicationUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace Drogaria.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UsersController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        [Authorize]
        [Route("login")]
        public async Task<IActionResult> CriarTokenIdentity([FromBody] LoginViewModel login)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(login.Senha) || string.IsNullOrWhiteSpace(login.Cpf))
                    return Unauthorized();
                var resultado = await _signInManager.PasswordSignInAsync(login.Cpf, login.Senha, false, lockoutOnFailure: false);
                if (resultado.Succeeded)
                {
                    var user = new ApplicationUser
                    {
                        UserName = login.Cpf
                    };
                    var userCurrent = await _userManager.FindByNameAsync(login.Cpf);

                    string usuarioId = userCurrent.Id;

                    var token = new TokenJWTBuilder()
                        .AddSecurityKey(JwtSecurityKey.Create(usuarioId))
                        .AddSubject("Drogaria Bruno soluções")
                        .AddIssuer("Drogaria.Security.Bearer")
                        .AddAudience("User.Drogaria.Security.Bearer")
                        .AddClaim("usuarioId", usuarioId)
                        .AddClaim("tipoUsuario", userCurrent.TipoUsuario.ToString())
                        .Builder();

                    return Ok(token.value);
                }
                else { return Unauthorized(); }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("criarUsuario")]
        public async Task<IActionResult> CriarUsuario([FromBody] NovoUsuarioViewModel novoUsuario)
        {
            if (string.IsNullOrWhiteSpace(novoUsuario.Cpf) || string.IsNullOrWhiteSpace(novoUsuario.Nome))
                return BadRequest("Preencha todos os campos.");

            var usuario = new ApplicationUser { 
                UserName = novoUsuario.Cpf,
                Cpf = novoUsuario.Cpf,
                Nome = novoUsuario.Nome,
                TipoUsuario = novoUsuario.TipoUsuario,               
            };

            var resultado = await _userManager.CreateAsync(usuario, novoUsuario.Senha);
            if(resultado.Errors.Any())
                return Ok(resultado.Errors);
            var usuarioId = await _userManager.GetUserIdAsync(usuario);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var resultado2 = await _userManager.ConfirmEmailAsync(usuario, code);

            if (resultado2.Succeeded)
                return Ok("Usuário criado com sucesso!");
            else
                return BadRequest("Erro ao criar usuário");
        }
    }
}
