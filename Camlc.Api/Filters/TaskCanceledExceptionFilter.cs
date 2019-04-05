using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Lepecki.Playground.Camlc.Api.Filters
{
    public class TaskCanceledExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                if (context.Exception is TaskCanceledException)
                {
                    context.ExceptionHandled = true;
                    context.Result = new NoContentResult();
                }
            }
        }
    }
}
