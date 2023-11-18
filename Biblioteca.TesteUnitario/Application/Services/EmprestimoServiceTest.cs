﻿using AutoMapper;
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
        [Fact(DisplayName = "ObterEmprestimos01 - Deve retornar erro por não encontrar o cliente")]
        public void ObterEmprestimos01()
        {
            long clienteId = 0;
            bool apenasEmprestimosPendentes = false;
            var exception = Assert.Throws<Exception>(() => _emprestimoService.ObterEmprestimos(clienteId, apenasEmprestimosPendentes));
            Assert.Equal("Cliente não encontrado.", exception.Message);
        }
        [Fact(DisplayName = "ObterEmprestimos02 - Deve retornar todos os emprestimos do cliente")]
        public void ObterEmprestimos02()
        {
            long clienteId = 0;
            bool apenasEmprestimosPendentes = false;

            ClienteDTO cliente = new ClienteDTO("Email Teste", "NomeTeste");

            _clienteService.Setup(p => p.ClienteGetAById(clienteId)).Returns(cliente);

            Emprestimo emprestimoNaoDevolvido = new Emprestimo { ClienteId = clienteId, DataEmprestimo = DateTimeOffset.Now, LivroId = 1 };
            Emprestimo emprestimoDevolvido = new Emprestimo { ClienteId = clienteId, DataEmprestimo = DateTimeOffset.Now, LivroId = 2, DataDevolucao = DateTimeOffset.Now };

            List<Emprestimo> clienteEmprestimos = new List<Emprestimo>();
            clienteEmprestimos.Add(emprestimoDevolvido);
            clienteEmprestimos.Add(emprestimoNaoDevolvido);
            var clienteEmprestimoNaoDevolvidos = clienteEmprestimos.Where(s => s.DataDevolucao == null).ToList();
            _repositoryMock.Setup(x => x.Buscar(p => p.ClienteId == clienteId && p.DataDevolucao == null && p.Excluido == false)).Returns(clienteEmprestimoNaoDevolvidos);
            _repositoryMock.Setup(x => x.Buscar(p => p.ClienteId == clienteId && p.Excluido == false)).Returns(clienteEmprestimos);

            var resultado = _emprestimoService.ObterEmprestimos(clienteId, apenasEmprestimosPendentes);
            for (int i = 0; i < resultado.Count; i++)
            {
                Assert.Equal(clienteEmprestimoNaoDevolvidos[i].LivroId,  resultado[i].LivroId);
            }
        }
        [Fact(DisplayName = "ObterEmprestimos03 - Deve retornar todos os emprestimos pendentes de devolução do cliente")]
        public void ObterEmprestimos03()
        {
            long clienteId = 0;
            bool apenasEmprestimosPendentes = true;

            ClienteDTO cliente = new ClienteDTO("Email Teste", "NomeTeste");

            _clienteService.Setup(p => p.ClienteGetAById(clienteId)).Returns(cliente);

            Emprestimo emprestimoNaoDevolvido = new Emprestimo { ClienteId = clienteId, DataEmprestimo = DateTimeOffset.Now, LivroId = 1 };
            Emprestimo emprestimoDevolvido = new Emprestimo { ClienteId = clienteId, DataEmprestimo = DateTimeOffset.Now, LivroId = 2, DataDevolucao = DateTimeOffset.Now };

            List<Emprestimo> clienteEmprestimos = new List<Emprestimo>();
            clienteEmprestimos.Add(emprestimoDevolvido);
            clienteEmprestimos.Add(emprestimoNaoDevolvido);
            var clienteEmprestimoNaoDevolvidos = clienteEmprestimos.Where(s => s.DataDevolucao == null).ToList();
            _repositoryMock.Setup(x => x.Buscar(p => p.ClienteId == clienteId  && p.Excluido == false && p.DataDevolucao == null)).Returns(clienteEmprestimoNaoDevolvidos);
            _repositoryMock.Setup(x => x.Buscar(p => p.ClienteId == clienteId && p.Excluido == false && true)).Returns(clienteEmprestimos);

            var resultado = _emprestimoService.ObterEmprestimos(clienteId, apenasEmprestimosPendentes);
            for (int i = 0; i < resultado.Count; i++)
            {
                Assert.Equal(clienteEmprestimos[i].LivroId, resultado[i].LivroId);
            }
        }
    }
}
