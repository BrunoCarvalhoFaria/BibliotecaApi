using Biblioteca.Domain.DTO;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Dapper;
using DrPay.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infra.Data.Repository
{
    public class EmprestimoRepository : Repository<Emprestimo>, IEmprestimoRepository
    {
        private readonly DbContextOptions<BibliotecaDbContext> _optionsBuilder;

        public EmprestimoRepository(BibliotecaDbContext context) : base(context)
        {
            _optionsBuilder = new DbContextOptions<BibliotecaDbContext>();
        }


        public List<EstoqueConsultaDTO> ObterEmprestimos(long clienteId, bool apenasPendentesDevolucao)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine($@"select * from emprestimo a
                            inner join Cliente b on b.Id = a.ClienteId
                            inner join Livro c on c.Id = a.LivroId
                            where 
                            a.ClienteId = {clienteId}
                            and (a.DataDevolucao is not null or {!apenasPendentesDevolucao})");
            return data.Database.GetDbConnection().Query<EstoqueConsultaDTO>(sql.ToString()).ToList();
        }
    }
}
