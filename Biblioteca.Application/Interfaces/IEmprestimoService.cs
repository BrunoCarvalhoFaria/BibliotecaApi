using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Interfaces
{
    public interface IEmprestimoService
    {
        Task<long> RealizarEmprestimo(long clienteId, long livroId);
        Task<long> RealizarDevolucao(long clienteId, long livroId, long emprestimoId);
    }
}
