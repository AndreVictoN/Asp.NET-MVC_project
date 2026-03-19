using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace FiapOnSmartCity.Controllers.Filters;

public class LogFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Debug.WriteLine("==========================================================");
        Debug.WriteLine("== Iniciando a gravação da mensagem de  log");
        Debug.WriteLine("Controller : " + context.RouteData.Values["Controller"]  + " executado");
        Debug.WriteLine("Action : " + context.RouteData.Values["Action"] + " executado");
        Debug.WriteLine("Data e Hora : " + DateTime.Now);
        Debug.WriteLine("==========================================================");
    }
}