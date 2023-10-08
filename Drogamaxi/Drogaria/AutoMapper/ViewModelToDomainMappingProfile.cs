using AutoMapper;
using Drogaria.Api.ViewModel;
using Drogaria.Application.DTO;
using Drogaria.Domain.Entities.Faltas;

namespace Drogaria.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile :  Profile
    {
        public ViewModelToDomainMappingProfile() {
            CreateMap<FaltaDTO, FaltaPostViewModel>().ReverseMap();
        }
    }
}
