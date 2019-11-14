using AutoMapper;
using Eventos.IO.Application.Interfaces;
using Eventos.IO.Application.ViewModels;
using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Organizadores.Commands;
using Eventos.IO.Domain.Organizadores.Repository;

namespace Eventos.IO.Application.Services
{
    public class OrganizadorAppService : IOrganizadorAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IOrganizadorRepository _organizadorRepository;

        public OrganizadorAppService(IBus bus, IMapper mapper, IOrganizadorRepository organizadorRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _organizadorRepository = organizadorRepository;
        }
        public void Registrar(OrganizadorViewModel organizadorViewModel)
        {
            var registrarOrganizadorCommand = _mapper.Map<RegistrarOrganizadorCommand>(organizadorViewModel);
            _bus.SendCommand(registrarOrganizadorCommand);
        }
        public void Dispose()
        {
            _organizadorRepository.Dispose();
        }
    }
}
