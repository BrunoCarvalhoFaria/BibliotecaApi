using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Drogaria.Domain.Core.Models;
using Drogaria.Domain.Entities.ApplicationUsers;
using Drogaria.Domain.Entities.Faltas;

namespace Drogaria.Domain.Entities.Vendedores
{
    public class Vendedor : Entity<Vendedor>
    {
        [StringLength(200)]
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public int CodigoDeVenda { get; set; }
        public ICollection<Falta> Faltas { get; set; }

        public override bool EhValido()
        {
            return true;
        }

    }
}
