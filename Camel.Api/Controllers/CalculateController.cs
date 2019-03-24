using Lepecki.Playground.Camel.Api.Validation;
using Lepecki.Playground.Camel.Engine.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lepecki.Playground.Camel.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculateController : ControllerBase
    {
        private readonly ICalc _calc;

        public CalculateController(ICalc calc)
        {
            _calc = calc ?? throw new ArgumentNullException(nameof(calc));
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public ActionResult<decimal> Get([FromQuery, Required, InfixExpr] string expr)
        {
            return _calc.Calculate(expr);
        }
    }
}
