﻿using KissLog;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCoreIdentity.Extensions {
    public class AuditoriaFilter : IActionFilter {

        private readonly ILogger _logger;

        public AuditoriaFilter(ILogger logger) {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context) {
            if (context.HttpContext.User.Identity.IsAuthenticated) {
                var mensagem = $"{context.HttpContext.User.Identity.Name} acessou: {context.HttpContext.Request.GetDisplayUrl()}";
                _logger.Info(mensagem);
            }
        }
    }
}
