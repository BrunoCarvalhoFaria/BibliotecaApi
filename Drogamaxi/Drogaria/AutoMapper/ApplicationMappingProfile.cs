using AutoMapper;
using Drogaria.Application.DTO;
using Drogaria.Domain.Entities.Caixas;
using Drogaria.Domain.Entities.Faltas;
using Drogaria.Domain.Entities.Vendedores;

namespace Drogaria.Api.AutoMapper
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile() {
            CreateMap<VendedorDTO, Vendedor>().ReverseMap();
            CreateMap<CaixaDTO, Caixa>().ReverseMap();
            CreateMap<FaltaDTO, Falta>().ReverseMap();
        }
    }
}
