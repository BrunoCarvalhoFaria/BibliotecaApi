using Biblioteca.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Emprestimo : Entity<Emprestimo>
    {
        public long LivroId { get; set; }
        public long ClienteId { get; set; }
        public DateTimeOffset DataEmprestimo { get; set; }
        public DateTimeOffset? DataDevolucao { get; set; }
        public virtual Livro Livro { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
