﻿using AutoMapper;
using Biblioteca.Application.DTO;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IMapper _mapper;
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IUsuarioAutorizacaoService _usuarioAutorizacaoService;
        private readonly IClienteService _clienteService;
        private readonly ILivroService _livroService;
        private readonly IEstoqueService _estoqueService;
        public EmprestimoService(IEmprestimoRepository emprestimoRepository,
            IMapper mapper,
            IUsuarioAutorizacaoService usuarioAutorizacaoService,
            IClienteService clienteService,
            ILivroService livroService,
            IEstoqueService estoqueService
            )
        {
            _emprestimoRepository = emprestimoRepository;
            _usuarioAutorizacaoService = usuarioAutorizacaoService;
            _clienteService = clienteService;
            _livroService = livroService;
            _mapper = mapper;
            _estoqueService = estoqueService;
        }

        public async Task<long> RealizarEmprestimo(long clienteId, long livroId)
        {
            try
            {
                var cliente = _clienteService.ClienteGetAById(clienteId);
                if (cliente == null)
                    throw new Exception("Cliente não encontrado.");
                var livro = _livroService.LivroGetAById(livroId);
                if (livro == null)
                    throw new Exception("Livro não encontrado.");

                _estoqueService.AlterarEstoque(livroId, -1);
                Emprestimo emprestimo = new Emprestimo
                {
                    ClienteId = clienteId,
                    DataEmprestimo = DateTimeOffset.Now,
                    LivroId = livroId
                };
                await _emprestimoRepository.Add(emprestimo);
                return emprestimo.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<long> RealizarDevolucao(long clienteId, long livroId, long emprestimoId)
        {
            try
            {
                var cliente = _clienteService.ClienteGetAById(clienteId);
                if (cliente == null)
                    throw new Exception("Cliente não encontrado.");
                var livro = _livroService.LivroGetAById(livroId);
                if (livro == null)
                    throw new Exception("Livro não encontrado.");
                var emprestimo = _emprestimoRepository.GetById(emprestimoId);
                if (emprestimo == null)
                    throw new Exception("Emprestimo não encontrado.");

                _estoqueService.AlterarEstoque(livroId, 1);
                emprestimo.DataDevolucao = DateTimeOffset.Now;
                await _emprestimoRepository.Update(emprestimo);
                return emprestimo.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<EmprestimoDTO> ObterEmprestimos(long clienteId, bool apenasPendentesDevolucao)
        {
            try
            {
                if(_clienteService.ClienteGetAById(clienteId) == null)
                    throw new Exception("Cliente não encontrado.");
                return _mapper.Map<List<EmprestimoDTO>>( _emprestimoRepository.Buscar(p => p.ClienteId == clienteId && p.Excluido == false && apenasPendentesDevolucao ? p.DataDevolucao == null : true ).ToList());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
