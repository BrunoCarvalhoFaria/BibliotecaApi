using AutoMapper;
using Drogaria.Application.Interfaces;
using Drogaria.Domain.Interfaces;


namespace Drogaria.Application.Services
{
    public class FaltaService : IFaltaService
    {
        private readonly IMapper _mapper;
        private readonly IFaltaRepository _faltaRepository;
        private readonly IUsuarioAutorizacaoService _usuarioAutorizacaoService;
        public FaltaService(IFaltaRepository faltaRepository,
            IMapper mapper,
            IUsuarioAutorizacaoService usuarioAutorizacaoService)
        {
            _faltaRepository = faltaRepository;
            _usuarioAutorizacaoService = usuarioAutorizacaoService;
            _mapper = mapper;
        }
    }
}
