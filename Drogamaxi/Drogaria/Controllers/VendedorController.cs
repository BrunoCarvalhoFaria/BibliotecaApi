using AutoMapper;
using Drogaria.Application.DTO;
using Drogaria.Application.Interfaces;
using Drogaria.Application.Services;
using Drogaria.Domain.Entities.ApplicationUsers;
using Drogaria.Domain.Entities.Vendedores.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Drogaria.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorService _vendedorService;
        public VendedorController(
            SignInManager<ApplicationUser> signInManager,
            IVendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> VendedorPost(VendedorDTO vendedor)
        {
            try
            {
                return Ok(await _vendedorService.VendedorPost(vendedor));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("")]
        public  IActionResult VendedorGetAll()
        {
            try
            {
                return Ok( _vendedorService.VendedorGetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult VendedorGetById(long id)
        {
            try
            {
                return Ok( _vendedorService.VendedorGetAById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> VendedorPut(VendedorDTO vendedor)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
