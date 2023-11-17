using AutoMapper;
using Biblioteca.Application.DTO;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.Services
{
    public class LivroService : ILivroService
    {
        private readonly IMapper _mapper;
        private readonly ILivroRepository _livroRepository;
        private readonly IUsuarioAutorizacaoService _usuarioAutorizacaoService;
        public LivroService(ILivroRepository livroRepository,
            IMapper mapper,
            IUsuarioAutorizacaoService usuarioAutorizacaoService)
        {
            _livroRepository = livroRepository;
            _usuarioAutorizacaoService = usuarioAutorizacaoService;
            _mapper = mapper;
        }

        public async Task<long> LivroPost(LivroDTO dto)
        {
            try
            {
                Livro livro = _mapper.Map<Livro>(dto);
                await _livroRepository.Add(livro);
                return livro.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
               
        public LivroDTO? LivroGetAById(long id)
        {
            try
            {
                return _mapper.Map<LivroDTO>(_livroRepository.GetById(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string LivroDelete(long id)
        {
            try
            {
                Livro? livro = _livroRepository.GetById(id);
                if (livro == null)
                    throw new Exception("Livro não encontrado");
                livro.Excluir();
                _livroRepository.Update(livro);
                return "Livro excluído com sucesso";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string LivroPut(LivroDTO dto)
        {
            try
            {
                _livroRepository.Update(_mapper.Map<Livro>(dto));
                return "Sucesso ao alterar o livro.";

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
