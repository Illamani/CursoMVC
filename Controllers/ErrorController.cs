using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CursoIndio.Controllers
{
    public class ErrorController : Controller
    {
        public ILogger<ErrorController> _loger { get; }

        public ErrorController(ILogger<ErrorController> loger)
        {
            _loger = loger;
        }
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";
                    _loger.LogWarning($"404 Error Ocured. Path = {statusCodeResult?.OriginalPath} and queryString = {statusCodeResult?.OriginalQueryString}");
                    break;
            }
            return View("NotFound");
        }

        [AllowAnonymous]
        [Route("Error")]
        public IActionResult Error()
        {
            // Retrieve the exception Details
            var exceptionHandlerPathFeature =
                    HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            _loger.LogError($"The path {exceptionHandlerPathFeature.Path} threw exception {exceptionHandlerPathFeature.Error}");

            return View("Error");
        }
    }
}
