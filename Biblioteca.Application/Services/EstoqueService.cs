using AutoMapper;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;

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
        public long AdicionarNoEstoque(long livroId, long qtd)
        {
            try
            {
                Estoque? estoque = _estoqueRepository.Buscar(p => p.LivroId == livroId).FirstOrDefault();
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
