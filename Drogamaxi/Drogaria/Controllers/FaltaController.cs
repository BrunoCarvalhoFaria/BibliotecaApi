using Drogaria.Application.Interfaces;
using Drogaria.Domain.Entities.ApplicationUsers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Drogaria.Api.Controllers
{
    public class FaltaController : ControllerBase
    {
        private readonly IFaltaService _faltaService;
        public FaltaController(
            SignInManager<ApplicationUser> signInManager,
            IFaltaService faltaService)
        {
            _faltaService = faltaService;
        }
    }
}
