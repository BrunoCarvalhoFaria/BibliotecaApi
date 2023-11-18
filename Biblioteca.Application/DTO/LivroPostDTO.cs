using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.DTO
{
    public class LivroPostDTO
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Ano { get; set; }
        public long LivroGeneroId { get; set; }
        public string Editora { get; set; }
    }
}
