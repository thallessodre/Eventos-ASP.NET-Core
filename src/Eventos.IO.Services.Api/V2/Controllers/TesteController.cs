using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Interfaces;
using Eventos.IO.Services.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.IO.Services.Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}")]
    public class TesteController : BaseController
    {
        public TesteController(IDomainNotificationHandler<DomainNotification> notifications, IBus bus, IUser user) : base(notifications, bus, user)
        {
        }

        [HttpGet("teste")]
        public string Teste()
        {
            return "Eu sou a V2";
        }
    }
}
