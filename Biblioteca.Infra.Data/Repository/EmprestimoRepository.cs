using Biblioteca.Domain.DTO;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
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

    //    List<RetornoEstoqueDTO> ListarEstoque(List<long> livroIdList)
    //    {
    //        try
    //        {

    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }
    }
}
