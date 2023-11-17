using Biblioteca.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.TesteUnitario.Application.Mock
{
    internal class UsuarioAutorizacaoServiceFake : IUsuarioAutorizacaoService
    {
        public string ObterUsuarioLogado()
        {
            return "1";
        }

        public bool UsuarioLogadoAdministrador()
        {
            return true;
        }
    }
}
