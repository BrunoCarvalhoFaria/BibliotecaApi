using Drogaria.Application.Interfaces;
using Drogaria.Application.Services;
using Drogaria.Domain.Entities.Vendedores.Repository;
using Drogaria.Domain.Interfaces;
using Drogaria.Infra.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace Drogaria.Infra.CrossCutting.IoC
{
    public class Injector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IVendedorRepository, VendedorRepository>();
            services.AddScoped<ICaixaRepository, CaixaRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IFaltaRepository, FaltaRepository>();


            services.AddScoped<IUsuarioAutorizacaoService,  UsuarioAutorizacaoService>();
            services.AddScoped<IVendedorService, VendedorService>();
            services.AddScoped<ICaixaService, CaixaService>();
            services.AddScoped<IFaltaService, FaltaService>();
            
        }
    }
}
