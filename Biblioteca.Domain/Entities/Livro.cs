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
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Ano { get; set; }
        public string Genero { get; set; }
        public string Editora { get; set; }
    }
}
