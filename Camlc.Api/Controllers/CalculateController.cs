using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Com.Lepecki.Playground.Camlc.Api.Filters;
using Com.Lepecki.Playground.Camlc.Api.Models;
using Com.Lepecki.Playground.Camlc.Api.Validation;
using Com.Lepecki.Playground.Camlc.Engine.Abstractions;

namespace Com.Lepecki.Playground.Camlc.Api.Controllers
{
    [ApiController]
    [Route("api")]
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
        [ApiVersion("1.0")]
        [Route("v{version:api-version}/[action]")]
        [NormalizeQueryParamFilter(ExprQueryParamName)]
        [CacheResultForQueryParamFilter(ExprQueryParamName, CachedExprResultsKey)]
        [ProducesResponseType(typeof(ExprResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public ActionResult<ExprResult> Calculate([FromQuery, InfixExpr] string expr, CancellationToken cancellationToken)
        {
            return new ExprResult
            {
                Expr = expr,
                Result = _calc.Calculate(expr)
            };
        }

        [HttpGet]
        [ApiVersion("2.0")]
        [Route("v{version:api-version}/[action]")]
        [NormalizeQueryParamFilter(ExprQueryParamName)]
        [CacheResultForQueryParamFilter(ExprQueryParamName, CachedExprResultsKey)]
        [ProducesResponseType(typeof(ExprResult[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ExprResult[]>> Calculate([FromQuery, InfixMultiExpr] string[] expr, CancellationToken cancellationToken)
        {
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
