using System;
using System.Linq;
using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Eventos.IO.Services.Api.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IDomainNotificationHandler<DomainNotification> _notifications;
        protected readonly IBus _bus;
        protected Guid OrganizadorId { get; set; }

        public BaseController(IDomainNotificationHandler<DomainNotification> notifications, IBus bus, IUser user)
        {
            _notifications = notifications;
            _bus = bus;

            if (user.IsAuthenticated())
            {
                OrganizadorId = user.GetUserId();
            }
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return Response();
        }

        protected ActionResult Response(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new {
                    sucess = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                sucess = false,
                errors = _notifications.GetNotifications().Select(n=> n.Value)
            }); ;
        }

        protected bool OperacaoValida()
        {
            return (!_notifications.HasNotifications());
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                NotificarErro(string.Empty, erro.ErrorMessage);
            }
        }

        protected void AdicionarErrosIdentity(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                NotificarErro(result.ToString(), error.Description);
            }
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _bus.RaiseEvent(new DomainNotification(codigo, mensagem));
        }
    }
}