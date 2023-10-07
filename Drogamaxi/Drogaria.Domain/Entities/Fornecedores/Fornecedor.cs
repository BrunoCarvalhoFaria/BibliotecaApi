using Drogaria.Domain.Core.Models;
using Drogaria.Domain.Entities.Faltas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drogaria.Domain.Entities.Fornecedores
{
    public class Fornecedor : Entity<Fornecedor>
    {
        public string Nome { get; set; } = "";
        public ICollection<Falta> Faltas { get; set; }
        public override bool EhValido()
        {
            return true;
        }
    }
}
