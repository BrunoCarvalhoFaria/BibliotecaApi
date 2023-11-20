using AutoMapper;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Services
{
    public class RabbitMensagemService : IRabbitMensagemService
    {
        private readonly IMapper _mapper;
        private readonly IRabbitMensagemRepository _rabbitMensagemRepository;

        public RabbitMensagemService(
            IMapper mapper,
            IRabbitMensagemRepository rabbitMensagemRepository
            )
        {
            _mapper = mapper;
            _rabbitMensagemRepository = rabbitMensagemRepository;
        }
        public void EnviarMensagem(RabbitMensagemDTO mensagem)
        {
            _rabbitMensagemRepository.EnviarMensagem(_mapper.Map<RabbitMensagem>(mensagem));
        }
    }
}
