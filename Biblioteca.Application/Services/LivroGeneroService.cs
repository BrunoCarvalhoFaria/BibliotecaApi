﻿using AutoMapper;
using Biblioteca.Application.DTO;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.Services
{
    public class LivroGeneroService : ILivroGeneroService
    {
        private readonly IMapper _mapper;
        private readonly ILivroGeneroRepository _livroGeneroRepository;
        private readonly IUsuarioAutorizacaoService _usuarioAutorizacaoService;
        private readonly IUtilsService _utilsService;
        public LivroGeneroService(ILivroGeneroRepository livroGeneroRepository,
            IMapper mapper,
            IUsuarioAutorizacaoService usuarioAutorizacaoService,
            IUtilsService utilsService)
        {
            _livroGeneroRepository = livroGeneroRepository;
            _usuarioAutorizacaoService = usuarioAutorizacaoService;
            _mapper = mapper;
            _utilsService = utilsService;
        }

        public List<LivroGeneroDTO> Obtertodos()
        {
            try
            {
                return _mapper.Map<List<LivroGeneroDTO>>(_livroGeneroRepository.GetAll().ToList());
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<long> LivroGeneroPost(string descricao)
        {
            try
            {
                if (string.IsNullOrEmpty(descricao))
                    throw new Exception("Deve conter uma descrição.");
                LivroGenero livroGenero = new(descricao);
                await _livroGeneroRepository.Add(livroGenero);
                return livroGenero.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public LivroGeneroDTO? LivroGeneroGetAById(long id)
        {
            try
            {
                return _mapper.Map<LivroGeneroDTO>(_livroGeneroRepository.GetById(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string LivroGeneroDelete(long id)
        {
            try
            {
                LivroGenero? livroGenero = _livroGeneroRepository.GetById(id);
                if (livroGenero == null)
                    throw new Exception("LivroGenero não encontrado");
                livroGenero.Excluir();
                _livroGeneroRepository.Update(livroGenero);
                return "LivroGenero excluído com sucesso";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string LivroGeneroPut(LivroGeneroDTO dto)
        {
            try
            {
                _livroGeneroRepository.Update(_mapper.Map<LivroGenero>(dto));
                return "Sucesso ao alterar o livroGenero.";

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
