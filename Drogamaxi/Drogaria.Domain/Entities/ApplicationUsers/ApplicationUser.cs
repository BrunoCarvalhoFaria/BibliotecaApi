using Drogaria.Domain.Core.Enums;
using Drogaria.Domain.Entities.Caixas;
using Drogaria.Domain.Entities.Faltas;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drogaria.Domain.Entities.ApplicationUsers
{
    public class ApplicationUser : IdentityUser
    {
        public string Cpf { get; set; } = "";
        public string Nome { get; set; } = "";
        public TipoUsuario TipoUsuario { get; set; } = TipoUsuario.Vendedor;
        public ICollection<Caixa> Caixas { get; set; }
        public ICollection<Falta> Faltas { get; set; }
    }
}
