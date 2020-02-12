using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System;
using Elmah.Io.Client.Models;
using Elmah.Io.Client;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Eventos.IO.Infra.CrossCutting.AspNetFilters
{
    public class GlobalActionLogger : IActionFilter
    {
        private readonly ILogger<GlobalActionLogger> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;

        public GlobalActionLogger(ILogger<GlobalActionLogger> logger, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (_hostingEnvironment.IsDevelopment())
            {
                var data = new
                {
                    Version = "v1.0",
                    User = context.HttpContext.User.Identity.Name,
                    IP = context.HttpContext.Connection.RemoteIpAddress.ToString(),
                    Hostname = context.HttpContext.Request.Host.ToString(),
                    AreaAccessed = context.HttpContext.Request.GetDisplayUrl(),
                    Action = context.ActionDescriptor.DisplayName,
                    TimeStamp = DateTime.Now
                };

                _logger.LogInformation(1, data.ToString());
            }

            if (_hostingEnvironment.IsProduction())
            {
                var message = new CreateMessage
                {
                    Version = "v1.0",
                    Application = "duoSpeak",
                    Source = "GlobalActionLoggerFilter",
                    User = context.HttpContext.User.Identity.Name,
                    Hostname = context.HttpContext.Request.Host.Host,
                    Url = context.HttpContext.Request.GetDisplayUrl(),
                    DateTime = DateTime.Now,
                    Method = context.HttpContext.Request.Method,
                    StatusCode = context.HttpContext.Response.StatusCode,
                    Cookies = context.HttpContext.Request?.Cookies?.Keys.Select(k => new Item(k, context.HttpContext.Request.Cookies[k])).ToList(),
                    Form = Form(context.HttpContext),
                    ServerVariables = context.HttpContext.Request?.Headers?.Keys.Select(k => new Item(k, context.HttpContext.Request.Headers[k])).ToList(),
                    QueryString = context.HttpContext.Request?.Query?.Keys.Select(k => new Item(k, context.HttpContext.Request.Query[k])).ToList(),
                    Data = context.Exception?.ToDataList(),
                    Detail = JsonConvert.SerializeObject(new { DadoExtra = "Dado a mais", DadoInfo = "Pode ser um Json"})
                };

                var client = ElmahioAPI.Create("aa9db5ab723a4d34a6cdfa1def53fd92");
                client.Messages.Create(new Guid("f212c380-9733-436a-942b-b34256d04a4d").ToString(), message);
            }
        }

        private static List<Item> Form(HttpContext httpContext)
        {
            try
            {
                return httpContext.Request?.Form?.Keys.Select(k => new Item(k, httpContext.Request.Form[k])).ToList();
            }
            catch (InvalidOperationException)
            {

                // Não faz nada
            }
            return null;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //throw new System.NotImplementedException();
        }
    }
}
