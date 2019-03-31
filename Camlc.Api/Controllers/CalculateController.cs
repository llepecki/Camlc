using Lepecki.Playground.Camlc.Api.Filters;
using Lepecki.Playground.Camlc.Api.Validation;
using Lepecki.Playground.Camlc.Engine.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lepecki.Playground.Camlc.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculateController : ControllerBase
    {
        private const string ExprQueryParamName = "expr";
        
        private readonly ICalc _calc;

        public CalculateController(ICalc calc)
        {
            _calc = calc ?? throw new ArgumentNullException(nameof(calc));
        }

        [HttpGet]
        [Route("")]
        [NormalizeQueryParam(ExprQueryParamName)]
        [CacheResultForQueryParam(ExprQueryParamName)]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status304NotModified)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public ActionResult<decimal> Calculate([FromQuery, InfixExpr] string expr) dodac cancellationtoken, w ICalc dodaprzeladowanie, ktore przyjmuje token, dodac opoznienie w petli i zobaczyc jak dziala cacheowanie
        {
            return _calc.Calculate(expr);
        }
    }
}
