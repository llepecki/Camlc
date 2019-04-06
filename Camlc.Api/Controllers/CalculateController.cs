using Lepecki.Playground.Camlc.Api.Filters;
using Lepecki.Playground.Camlc.Api.Models;
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
        private const string CachedExprResultsKey = "cached-expr-results-key";

        private readonly ICalc _calc;

        public CalculateController(ICalc calc)
        {
            _calc = calc ?? throw new ArgumentNullException(nameof(calc));
        }

        [HttpGet]
        [Route("")]
        [NormalizeQueryParamFilter(ExprQueryParamName)]
        [CacheResultForQueryParamFilter(ExprQueryParamName, CachedExprResultsKey)]
        [ProducesResponseType(typeof(ExprResult[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        // TODO: output formatters for xml, json, csv; move this controller to v1.1 (or v2) and create old one with single expr, use versioning
        public async Task<ActionResult<ExprResult[]>> Calculate([FromQuery, InfixMultiExpr] string[] expr, CancellationToken cancellationToken)
        {
            // TODO: human readable output (2ADDNEG3) -> (2 ADD NEG 3)

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
