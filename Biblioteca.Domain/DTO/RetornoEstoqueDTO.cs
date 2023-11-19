using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.DTO
{
    public class RetornoEstoqueDTO
    {
        public string NomeLivro { get; set; }
        public long EstoqueAtual { get; set; }
        public long QtdEmprestado { get; set; }
    }
}
