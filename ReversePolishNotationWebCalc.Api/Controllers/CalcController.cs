using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReversePolishNotationWebCalc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<string> Get([FromQuery] string input)
        {
            return input;
        }
    }
}
