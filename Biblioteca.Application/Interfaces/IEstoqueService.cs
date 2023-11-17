using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.Interfaces
{
    public interface IEstoqueService
    {
        long CalcularEstoque(Estoque estoque, long qtd);
    }
}
