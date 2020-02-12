using System.Diagnostics;
using Eventos.IO.Domain.Interfaces;
using Eventos.IO.Infra.CrossCutting.AspNetFilters;
using Eventos.IO.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eventos.IO.Site.Controllers
{
    public class ErrosController : Controller
    {
        private readonly IUser _user;
        //private readonly ILogger<GlobalExceptionHandlingFilter> _logger;

        public ErrosController(IUser user)
        {
            _user = user;
            //_logger = logger;
        }

        [Route("/erro-de-aplicacao")]
        [Route("/erro-de-aplicacao/{id}")]
        public IActionResult Erros(string id)
        {
            switch (id)
            {
                case "404":
                    //_logger.LogError("Página não encontrada: 404");
                    return View("NotFound");
                case "403":
                    //_logger.LogError("Proibido: 403");
                    return View("Forbidden");
                case "401":
                    //_logger.LogError("Acesso Negado: 401");
                    if (!_user.IsAuthenticated()) return LocalRedirect("/Identity/Account/Login");
                    return View("AccessDenied");
                case "500":
                    //_logger.LogError("Erro interno do servidor: 500");
                    return View("InternalServerError");
            }
            //_logger.LogError("Erro não identificado");
            return View("Erro");
        }
    }
}
