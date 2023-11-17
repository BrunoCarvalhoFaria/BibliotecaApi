using AutoMapper;
using Biblioteca.Application.DTO;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Api.AutoMapper
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile() {
            CreateMap<ClienteDTO, ClienteDTO>().ReverseMap();
            CreateMap<LivroDTO, Livro>().ReverseMap();
        }
    }
}
