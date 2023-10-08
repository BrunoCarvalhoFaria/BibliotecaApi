
using Drogaria.Application.DTO;

namespace Drogaria.Application.Interfaces
{
    public interface IFaltaService
    {
        long FaltaPost(FaltaDTO dto);
        List<FaltaDTO> FaltaGetAll();
        FaltaDTO? FaltaGetAById(long id);
        string FaltaPut(FaltaDTO dto);
    }
}
