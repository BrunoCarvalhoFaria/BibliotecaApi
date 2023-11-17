﻿using Biblioteca.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Interfaces
{
    public interface IClienteService
    {
        Task<long> ClientePost(ClienteDTO dto);
        ClienteDTO? ClienteGetAById(long id);
        string ClienteDelete(long id);
        string ClientePut(ClienteDTO dto);
    }
}