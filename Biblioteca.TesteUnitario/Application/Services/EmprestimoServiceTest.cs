using AutoMapper;
using Biblioteca.Application.AutoMapper;
using Biblioteca.Application.DTO;
using Biblioteca.Application.Interfaces;
using Biblioteca.Application.Services;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infra.Data.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.TesteUnitario.Application.Services
{
    public class EmprestimoServiceTest
    {
        private readonly IEmprestimoService _emprestimoService;
        private readonly Mock<IUsuarioAutorizacaoService> _usuarioAutorizacaoServiceMock;
        private readonly Mock<IEmprestimoRepository> _repositoryMock;
        private readonly Mock<IClienteService> _clienteService;
        private readonly Mock<ILivroService> _livroService;
        private readonly Mock<IEstoqueService> _estoqueService;
        public EmprestimoServiceTest()
        {
            _usuarioAutorizacaoServiceMock = new Mock<IUsuarioAutorizacaoService>();
            _clienteService = new Mock<IClienteService>();
            _livroService = new Mock<ILivroService>();
            _estoqueService = new Mock<IEstoqueService>();

            _repositoryMock = new Mock<IEmprestimoRepository>();
            var configuration = new MapperConfiguration(options =>
            {
                options.AddProfile<ApplicationMappingProfile>();
                options.AllowNullCollections = true;
            });
            IMapper mapper = new Mapper(configuration);

            _emprestimoService = new EmprestimoService(_repositoryMock.Object, mapper, _usuarioAutorizacaoServiceMock.Object, _clienteService.Object, _livroService.Object, _estoqueService.Object);
        }
        [Fact(DisplayName = "RealizarEmprestimo01 - Deve retornar erro por não encontrar o cliente")]
        public async Task RealizarEmprestimo01()
        {
            long clienteId = 0;
            long livroId = 0;
            LivroDTO livro = new LivroDTO
            {
                Titulo = "Título Teste",
                Autor = "Autor Teste",
                Ano = "2022",
                Editora = "Editora Teste",
                LivroGeneroId = 1,
            };
            _livroService.Setup(p => p.LivroGetAById(livroId)).Returns(livro);
            var exception = await  Assert.ThrowsAsync<Exception>(() => _emprestimoService.RealizarEmprestimo(clienteId, livroId));
            Assert.Equal("Cliente não encontrado.", exception.Message);
            
        }
        [Fact(DisplayName = "RealizarEmprestimo02 - Deve retornar erro por não encontrar o livro")]
        public async Task RealizarEmprestimo02()
        {
            long clienteId = 0;
            long livroId = 0;
            ClienteDTO cliente = new ClienteDTO("Email Teste", "NomeTeste");

            _clienteService.Setup(p => p.ClienteGetAById(clienteId)).Returns(cliente);
            var exception = await  Assert.ThrowsAsync<Exception>(() => _emprestimoService.RealizarEmprestimo(clienteId, livroId));
            Assert.Equal("Livro não encontrado.", exception.Message);
        }
        [Fact(DisplayName = "RealizarEmprestimo03 - Deve realizar o emprestimo")]
        public async Task RealizarEmprestimo03()
        {
            long clienteId = 0;
            long livroId = 0;
            LivroDTO livro = new LivroDTO
            {
                Titulo = "Título Teste",
                Autor = "Autor Teste",
                Ano = "2022",
                Editora = "Editora Teste",
                LivroGeneroId = 1,
            };
            ClienteDTO cliente = new ClienteDTO("Email Teste", "NomeTeste");

            _livroService.Setup(p => p.LivroGetAById(livroId)).Returns(livro);
            _clienteService.Setup(p => p.ClienteGetAById(clienteId)).Returns(cliente);

            var resultado = await _emprestimoService.RealizarEmprestimo(clienteId, livroId);
            Assert.Equal(0, resultado);
        }


        [Fact(DisplayName = "RealizarDevolucao01 - Deve retornar erro por não encontrar o cliente")]
        public async Task RealizarDevolucao01()
        {
            long clienteId = 0;
            long livroId = 0;
            long emprestimoId = 0;
            LivroDTO livro = new LivroDTO
            {
                Titulo = "Título Teste",
                Autor = "Autor Teste",
                Ano = "2022",
                Editora = "Editora Teste",
                LivroGeneroId = 1,
            };
            _livroService.Setup(p => p.LivroGetAById(livroId)).Returns(livro);
            var exception = await Assert.ThrowsAsync<Exception>(() => _emprestimoService.RealizarDevolucao(clienteId, livroId, emprestimoId));
            Assert.Equal("Cliente não encontrado.", exception.Message);

        }
        [Fact(DisplayName = "RealizarDevolucao02 - Deve retornar erro por não encontrar o livro")]
        public async Task RealizarDevolucao02()
        {
            long clienteId = 0;
            long livroId = 0;
            long emprestimoId = 0;
            ClienteDTO cliente = new ClienteDTO("Email Teste", "NomeTeste");

            _clienteService.Setup(p => p.ClienteGetAById(clienteId)).Returns(cliente);
            var exception = await Assert.ThrowsAsync<Exception>(() => _emprestimoService.RealizarDevolucao(clienteId, livroId, emprestimoId));
            Assert.Equal("Livro não encontrado.", exception.Message);
        }
        [Fact(DisplayName = "RealizarDevolucao03 - Deve retornar erro por não encontrar o emprestimo")]
        public async Task RealizarDevolucao03()
        {
            long clienteId = 0;
            long livroId = 0;
            long emprestimoId = 0;
            ClienteDTO cliente = new ClienteDTO("Email Teste", "NomeTeste");
            LivroDTO livro = new LivroDTO
            {
                Titulo = "Título Teste",
                Autor = "Autor Teste",
                Ano = "2022",
                Editora = "Editora Teste",
                LivroGeneroId = 1,
            };
            _livroService.Setup(p => p.LivroGetAById(livroId)).Returns(livro);
            _clienteService.Setup(p => p.ClienteGetAById(clienteId)).Returns(cliente);
            var exception = await Assert.ThrowsAsync<Exception>(() => _emprestimoService.RealizarDevolucao(clienteId, livroId, emprestimoId));
            Assert.Equal("Emprestimo não encontrado.", exception.Message);
        }
        [Fact(DisplayName = "RealizarDevolucao04 - Deve realizar a devolução")]
        public async Task RealizarDevolucao04()
        {
            long clienteId = 0;
            long livroId = 0;
            long emprestimoId = 0;
            LivroDTO livro = new LivroDTO
            {
                Titulo = "Título Teste",
                Autor = "Autor Teste",
                Ano = "2022",
                Editora = "Editora Teste",
                LivroGeneroId = 1,
            };
            ClienteDTO cliente = new ClienteDTO("Email Teste", "NomeTeste");
            Emprestimo emprestimo = new Emprestimo
            {
                LivroId = livroId,
                ClienteId = clienteId,
                DataEmprestimo = DateTimeOffset.Now
            };

            _livroService.Setup(p => p.LivroGetAById(livroId)).Returns(livro);
            _clienteService.Setup(p => p.ClienteGetAById(clienteId)).Returns(cliente);
            _repositoryMock.Setup(p => p.GetById(emprestimoId)).Returns(emprestimo);

            var resultado = await _emprestimoService.RealizarDevolucao(clienteId, livroId, emprestimoId);
            Assert.Equal(0, resultado);
        }
    }
}
