using Microsoft.AspNetCore.Identity;

namespace Biblioteca.Domain.Entities.ApplicationUsers
{
    public class ApplicationUser : IdentityUser
    {
        public override string Email { get; set; } = "";
        public string Nome { get; set; } = "";
    }
}
