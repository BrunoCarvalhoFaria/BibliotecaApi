using Drogaria.Domain.Core.Enums;
using Drogaria.Domain.Entities.Caixas;
using Microsoft.AspNetCore.Identity;

namespace Drogaria.Domain.Entities.ApplicationUsers
{
    public class ApplicationUser : IdentityUser
    {
        public string Cpf { get; set; } = "";
        public string Nome { get; set; } = "";
        public TipoUsuario TipoUsuario { get; set; } = TipoUsuario.Vendedor;

        public ICollection<Caixa> Caixa { get; set; }
    }
}
