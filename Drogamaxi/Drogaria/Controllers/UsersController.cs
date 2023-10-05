using Drogaria.Api.Token;
using Drogaria.Api.ViewModel;
using Drogaria.Domain.Entities.ApplicationUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
        [Route("login")]
        [AllowAnonymous]
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

                    if (userCurrent == null)
                        return BadRequest("Falha ao buscar usuario");
                    
                    string usuarioId = userCurrent.Id;

                    var userClaims = await _userManager.GetClaimsAsync(userCurrent);

                    userClaims.Add(new Claim("usuarioId", usuarioId));
                    userClaims.Add(new Claim("tipoUsuario", userCurrent.TipoUsuario.ToString()));
                    var key = Encoding.ASCII.GetBytes("BrunoFaria0123456789_JWTToken_2023_Drogaria");
                    var tokenConfig = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(userClaims),
                        Expires = DateTime.UtcNow.AddHours(3),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenConfig);                    

                    return Ok(tokenHandler.WriteToken(token));
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
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
            //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var resultado2 = await _userManager.ConfirmEmailAsync(usuario, code);

            if (resultado2.Succeeded)
                return Ok("Usuário criado com sucesso!");
            else
                return BadRequest("Erro ao criar usuário");
        }
    }
}
