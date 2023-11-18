using AutoMapper;
using Biblioteca.Application.AutoMapper;
using Biblioteca.Application.Interfaces;
using Biblioteca.Application.Services;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infra.Data.Repository;
using Moq;
using System;

namespace Biblioteca.TesteUnitario.Application.Services
{
    public class EstoqueServiceTest
    {
        private readonly IEstoqueService _estoqueService;
        private readonly Mock<IUsuarioAutorizacaoService> _usuarioAutorizacaoServiceMock;
        private readonly Mock<IEstoqueRepository> _repositoryMock;
        public EstoqueServiceTest()
        {
            _usuarioAutorizacaoServiceMock = new Mock<IUsuarioAutorizacaoService>();

            _repositoryMock = new Mock<IEstoqueRepository>();
            var configuration = new MapperConfiguration(options =>
            {
                options.AddProfile<ApplicationMappingProfile>();
                options.AllowNullCollections = true;
            });
            IMapper mapper = new Mapper(configuration);

            _estoqueService = new EstoqueService(_repositoryMock.Object, mapper, _usuarioAutorizacaoServiceMock.Object);
        }
       
        [Fact(DisplayName = "CalcularEstoque01 - Deve alterar o estoque e verificar todas condições")]
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

        [Fact(DisplayName = "AlterarEstoque01 - Teste caso o estoque não seja encontrado")]
        public void AlterarEstoque01() {
            var exception = Assert.Throws<Exception>(() => _estoqueService.AlterarEstoque(0, 1));
            Assert.Equal("Estoque referente ao livro não encontrado.", exception.Message);
        }

        [Fact(DisplayName = "AlterarEstoque02 - Deve utilizar EstoqueRepository.Update uma vez")]
        public void AlterarEstoque02()
        {
            long livroId = 10;
            long qtdInserida = 1;
            Estoque estoque = new Estoque{
                LivroId = 10,
                Qtd = 10
            };
            List<Estoque> estoques = new List<Estoque>();
            estoques.Add(estoque);

            Estoque resultadoEsperado = new Estoque{
                LivroId = 10,
                Qtd = estoque.Qtd + qtdInserida
            };

            _repositoryMock.Setup(s => s.Buscar(p => p.LivroId == livroId)).Returns(estoques);
            Estoque resultado = _estoqueService.AlterarEstoque(livroId, qtdInserida);
            _repositoryMock.Verify(p => p.Update(resultado), Times.Once);
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
