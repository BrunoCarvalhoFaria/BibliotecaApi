using Biblioteca.Application.DTO;

namespace Biblioteca.Application.Interfaces
{
    public interface ILivroService
    {
        Task<long> LivroPost(LivroDTO dto);
        LivroDTO? LivroGetAById(long id);
        string LivroDelete(long id);
        string LivroPut(LivroDTO dto);
    }
}
