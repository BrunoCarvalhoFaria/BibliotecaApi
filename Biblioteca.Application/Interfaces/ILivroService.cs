using Biblioteca.Application.DTO;

namespace Biblioteca.Application.Interfaces
{
    public interface ILivroService
    {
        Task<long> LivroPost(LivroPostDTO dto);
        LivroDTO? LivroGetAById(long id);
        string LivroDelete(long id);
        Task<string> LivroPut(LivroDTO dto);
        LivroObterTodosDTO ObterTodos(int pagina, int qtdRegistros);
    }
}
