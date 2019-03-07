using System;
using Lepecki.Playground.ReversePolishNotationWebCalc.Engine;
using Microsoft.AspNetCore.Mvc;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Api.Controllers
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
        public ActionResult<double> Get([FromQuery] string expr)
        {
            return _calc.Calculate(expr);
        }
    }
}
