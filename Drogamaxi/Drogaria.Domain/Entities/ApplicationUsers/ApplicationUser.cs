using Drogaria.Domain.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drogaria.Domain.Entities.ApplicationUsers
{
    public class ApplicationUser : IdentityUser
    {
        public string Cpf { get; set; } = "";
        public string Nome { get; set; } = "";
        public TipoUsuario TipoUsuario { get; set; }
    }
}
