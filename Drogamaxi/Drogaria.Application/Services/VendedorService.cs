using AutoMapper;
using Drogaria.Application.DTO;
using Drogaria.Application.Interfaces;
using Drogaria.Domain.Entities.Vendedores;
using Drogaria.Domain.Entities.Vendedores.Repository;

namespace Drogaria.Application.Services
{
    public class VendedorService : IVendedorService
    {
        private readonly IMapper _mapper;
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IUsuarioAutorizacaoService _usuarioAutorizacaoService;
        public VendedorService(IVendedorRepository vendedorRepository,
            IMapper mapper,
            IUsuarioAutorizacaoService usuarioAutorizacaoService) { 
            _vendedorRepository = vendedorRepository;
            _usuarioAutorizacaoService = usuarioAutorizacaoService;
            _mapper = mapper;
        }

        public async Task<long> VendedorPost(VendedorDTO dto)
        {
            try
            {
                //if (!_usuarioAutorizacaoService.UsuarioLogadoAdministrador())
                //    throw new Exception("Usuário não autorizado");
                Vendedor vendedor = _mapper.Map<Vendedor>(dto);
                await _vendedorRepository.Add(vendedor);
                return vendedor.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<VendedorDTO> VendedorGetAll()
        {
            try
            {
                return  _mapper.Map< List<VendedorDTO>>(_vendedorRepository.GetAll());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public VendedorDTO? VendedorGetAById(long id)
        {
            try
            {
                return _mapper.Map<VendedorDTO>(_vendedorRepository.GetById(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
