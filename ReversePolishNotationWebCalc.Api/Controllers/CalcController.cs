using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReversePolishNotationWebCalc.Engine;

namespace ReversePolishNotationWebCalc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        private readonly ICalc _calc;

        public CalcController(ICalc calc)
        {
            if (calc == null)
            {
                throw new ArgumentNullException(nameof(calc));
            }

            _calc = calc;
        }

        [HttpGet()]
        public ActionResult<double> Get([FromQuery] string expr)
        {
            return _calc.Calculate(expr);
        }
    }
}
