using Biblioteca.Application.Interfaces;
using Biblioteca.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace Biblioteca.Infra.CrossCutting.IoC
{
    public class Injector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUsuarioAutorizacaoService,  UsuarioAutorizacaoService>();
            
        }
    }
}
