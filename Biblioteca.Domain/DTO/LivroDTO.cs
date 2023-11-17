using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.DTO
{
    internal class LivroDTO
    {
        public long Id {  get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Ano { get; set; }
        public string Genero { get; set; }
        public string Editora { get; set; }
    }
}
