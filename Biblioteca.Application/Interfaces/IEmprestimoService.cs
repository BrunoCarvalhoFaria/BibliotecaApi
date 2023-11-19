using Biblioteca.Application.DTO;
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
        long RealizarDevolucao(long emprestimoId);
        List<EmprestimoDTO> ObterEmprestimos(long clienteId, bool apenasPendentesDevolucao);
    }
}
