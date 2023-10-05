using AutoMapper;
using Drogaria.Application.DTO;
using Drogaria.Application.Interfaces;
using Drogaria.Domain.Entities.Caixas;
using Drogaria.Domain.Interfaces;

namespace Drogaria.Application.Services
{
    public class CaixaService : ICaixaService
    {
        private readonly IMapper _mapper;
        private readonly ICaixaRepository _CaixaRepository;
        private readonly IUsuarioAutorizacaoService _usuarioAutorizacaoService;
        public CaixaService(ICaixaRepository CaixaRepository,
            IMapper mapper,
            IUsuarioAutorizacaoService usuarioAutorizacaoService)
        {
            _CaixaRepository = CaixaRepository;
            _usuarioAutorizacaoService = usuarioAutorizacaoService;
            _mapper = mapper;
        }

        public async Task<long> CaixaPost(CaixaDTO dto)
        {
            try
            {
                //if (!_usuarioAutorizacaoService.UsuarioLogadoAdministrador())
                //    throw new Exception("Usuário não autorizado");
                Caixa caixa = _mapper.Map<Caixa>(dto);
                await _CaixaRepository.Add(caixa);
                return caixa.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CaixaDTO> CaixaGetAll()
        {
            try
            {
                return _mapper.Map<List<CaixaDTO>>(_CaixaRepository.GetAll());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CaixaDTO? CaixaGetAById(long id)
        {
            try
            {
                return _mapper.Map<CaixaDTO>(_CaixaRepository.GetById(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
