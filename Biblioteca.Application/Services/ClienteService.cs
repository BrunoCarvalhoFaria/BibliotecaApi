﻿using AutoMapper;
using Biblioteca.Application.DTO;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;
        private readonly IUsuarioAutorizacaoService _usuarioAutorizacaoService;
        public ClienteService(IClienteRepository clienteRepository,
            IMapper mapper,
            IUsuarioAutorizacaoService usuarioAutorizacaoService)
        {
            _clienteRepository = clienteRepository;
            _usuarioAutorizacaoService = usuarioAutorizacaoService;
            _mapper = mapper;
        }

        public async Task<long> ClientePost(ClienteDTO dto)
        {
            try
            {
                Cliente cliente = _mapper.Map<Cliente>(dto);
                await _clienteRepository.Add(cliente);
                return cliente.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ClienteDTO? ClienteGetAById(long id)
        {
            try
            {
                return _mapper.Map<ClienteDTO>(_clienteRepository.GetById(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ClienteDelete(long id)
        {
            try
            {
                Cliente? cliente = _clienteRepository.GetById(id);
                if (cliente == null)
                    throw new Exception("Cliente não encontrado");
                cliente.Excluir();
                _clienteRepository.Update(cliente);
                return "Cliente excluído com sucesso";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ClientePut(ClienteDTO dto)
        {
            try
            {
                _clienteRepository.Update(_mapper.Map<Cliente>(dto));
                return "Sucesso ao alterar o cliente.";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
