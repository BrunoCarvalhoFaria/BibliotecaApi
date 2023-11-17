using Biblioteca.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Livro : Entity<Livro>
    {
        public required string Titulo { get; set; }
        public required string Autor { get; set; }
        public required string Ano { get; set; }
        public required string Genero { get; set; }
        public required string Editora { get; set; }
    }
}
