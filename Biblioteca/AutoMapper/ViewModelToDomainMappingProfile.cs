using AutoMapper;
using Biblioteca.Api.ViewModel;
using Biblioteca.Application.DTO;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile :  Profile
    {
        public ViewModelToDomainMappingProfile() {
            CreateMap<LivroViewModel, LivroDTO>().ReverseMap();
        }
    }
}
