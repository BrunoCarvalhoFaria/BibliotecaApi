using AutoMapper;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IMapper _mapper;
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IUsuarioAutorizacaoService _usuarioAutorizacaoService;
        public EmprestimoService(IEmprestimoRepository emprestimoRepository,
            IMapper mapper,
            IUsuarioAutorizacaoService usuarioAutorizacaoService)
        {
            _emprestimoRepository = emprestimoRepository;
            _usuarioAutorizacaoService = usuarioAutorizacaoService;
            _mapper = mapper;
        }
    }
}
