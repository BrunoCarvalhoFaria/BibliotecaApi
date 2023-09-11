﻿using System.ComponentModel.DataAnnotations;
using Drogaria.Domain.Core.Models;


namespace Drogaria.Domain.Entities.Vendedores
{
    public class Vendedor : Entity<Vendedor>
    {
        [StringLength(200)]
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public int CodigoDeVenda { get; set; }
        public override bool EhValido()
        {
            return true;
        }

    }
}
