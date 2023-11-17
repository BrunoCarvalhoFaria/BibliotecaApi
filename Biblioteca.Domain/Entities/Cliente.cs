using Biblioteca.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Cliente : Entity<Cliente>
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
    }
}
