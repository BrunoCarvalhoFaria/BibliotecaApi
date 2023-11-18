﻿using AutoMapper;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using System.Reflection;

namespace Biblioteca.Application.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IMapper _mapper;
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IUsuarioAutorizacaoService _usuarioAutorizacaoService;
        public EstoqueService(IEstoqueRepository estoqueRepository,
            IMapper mapper,
            IUsuarioAutorizacaoService usuarioAutorizacaoService)
        {
            _estoqueRepository = estoqueRepository;
            _usuarioAutorizacaoService = usuarioAutorizacaoService;
            _mapper = mapper;
        }
        public long CalcularEstoque(Estoque estoque, long qtd)
        {
            try
            {
                estoque.Qtd += qtd;
                if (estoque.Qtd < 0)
                    throw new Exception("Estoque negativo não permitido");
                return estoque.Qtd;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public Estoque AlterarEstoque(long livroId, long qtd)
        {
            try
            {
                Estoque? estoque = _estoqueRepository.Buscar(p => p.LivroId == livroId).FirstOrDefault();
                if (estoque == null)
                    throw new Exception("Estoque referente ao livro não encontrado.");
                estoque.Qtd = CalcularEstoque(estoque, qtd);
                _estoqueRepository.Update(estoque);
                return estoque;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
