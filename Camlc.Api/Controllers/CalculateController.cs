using Lepecki.Playground.Camlc.Api.Filters;
using Lepecki.Playground.Camlc.Api.Validation;
using Lepecki.Playground.Camlc.Engine.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

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
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<decimal>> Calculate([FromQuery, InfixExpr] string expr, CancellationToken cancellationToken)
        {
            // ZMIENIĆ expr na expr[]
            // w outputowym JSONie zrobić (2 ADD 3) MUL 5 = 4, czyli dodać spacje naokoło operatorów
            return await _calc.CalculateAsync(expr, cancellationToken);
        }
    }
}
