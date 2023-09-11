using Drogaria.Domain.Core.Enums;

namespace Drogaria.Api.ViewModel
{
    public class NovoUsuarioViewModel
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public int? CodigoVenda { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public string Senha { get; set; }
    }
}
