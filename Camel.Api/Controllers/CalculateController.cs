using Lepecki.Playground.Camel.Engine.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lepecki.Playground.Camel.Api.Controllers
{
    [ApiController]
    [Route("api/calculate")]
    [ProducesResponseType(200, Type = typeof(double))]
    public class CalculateController : ControllerBase
    {
        private readonly ICalc _calc;

        public CalculateController(ICalc calc)
        {
            _calc = calc ?? throw new ArgumentNullException(nameof(calc));
        }

        [HttpGet]
        public ActionResult<double> Get([FromQuery] string expr)
        {
            return _calc.Calculate(expr);
        }
    }
}
