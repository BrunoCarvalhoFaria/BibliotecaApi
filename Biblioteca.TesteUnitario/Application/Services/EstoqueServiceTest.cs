using AutoMapper;
using Biblioteca.Application.Interfaces;

using Biblioteca.Application.Services;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infra.Data;
using Biblioteca.Infra.Data.Repository;
using Biblioteca.TesteUnitario.Application.Mock;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace Biblioteca.TesteUnitario.Application.Services
{
    public class EstoqueServiceTest
    {
        private readonly IEstoqueService _estoqueService;
        private readonly IUsuarioAutorizacaoService _usuarioAutorizacaoService;
        public EstoqueServiceTest()
        {
            //var service = new ServiceCollection();
            //service.AddTransient<IEstoqueService, EstoqueService>();
            //var provider = service.BuildServiceProvider();
            //_estoqueService = provider.GetService<IEstoqueService>();
            var _estoqueRepository = new EstoqueRepositoryFake();
            _usuarioAutorizacaoService = new UsuarioAutorizacaoServiceFake();
            var configuration = new MapperConfiguration(options =>
            {
                
            });
            IMapper mapper = new Mapper(configuration);

            _estoqueService = new EstoqueService(_estoqueRepository, mapper, _usuarioAutorizacaoService);
        }
       
        [Fact]
        public void CalcularEstoque()
        {
            Estoque estoque = new Estoque();
            estoque.Qtd = 10;
            
            Assert.Equal( 15, _estoqueService.CalcularEstoque(estoque, 5));
            estoque.Qtd = 10;
            Assert.Equal(0, _estoqueService.CalcularEstoque(estoque, -10));
            estoque.Qtd = 10;
            var exception = Assert.Throws<Exception>(() => _estoqueService.CalcularEstoque(estoque, -15));

            Assert.Equal("Estoque negativo não permitido", exception.Message);
        }
    }
}
