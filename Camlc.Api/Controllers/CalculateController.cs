using Lepecki.Playground.Camlc.Api.Filters;
using Lepecki.Playground.Camlc.Api.Models;
using Lepecki.Playground.Camlc.Api.Validation;
using Lepecki.Playground.Camlc.Engine.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lepecki.Playground.Camlc.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculateController : ControllerBase
    {
        private const string ExprQueryParamName = "expr";
        private const string CachedExprResultsKey = "cached-expr-results-key";

        private readonly ICalc _calc;

        public CalculateController(ICalc calc)
        {
            _calc = calc ?? throw new ArgumentNullException(nameof(calc));
        }

        [HttpGet]
        [Route("")]
        [NormalizeQueryParam(ExprQueryParamName)]
        [CacheResultForQueryParam(ExprQueryParamName, CachedExprResultsKey)]
        [ProducesResponseType(typeof(ExprResult[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        // TODO: output formatters for xml, json, csv
        public async Task<ActionResult<ExprResult[]>> Calculate([FromQuery, InfixExpr] string[] expr, CancellationToken cancellationToken)
        {
            // w outputowym JSONie zrobić (2 ADD 3) MUL 5 = 4, czyli dodać spacje naokoło operatorów

            var calculations = new Task<decimal>[expr.Length];

            for (int i = 0; i < expr.Length; i++)
            {
                calculations[i] = _calc.CalculateAsync(expr[i], cancellationToken);
            }

            decimal[] results = await Task.WhenAll(calculations);
            var exprResults = new ExprResult[expr.Length];

            for (int i = 0; i < expr.Length; i++)
            {
                exprResults[i] = new ExprResult { Expr = expr[i], Result = results[i] };
            }

            return exprResults;
        }
    }
}
