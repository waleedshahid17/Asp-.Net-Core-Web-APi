using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private ILoggerManager ilogger;
        public WeatherForecastController(ILoggerManager logger)
        {
            ilogger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            ilogger.LogInfo("Here is info message from our Controller");
            ilogger.LogWarn("Here is warning message from our Controller");
            ilogger.LogDebug("Here is debug message from our Controller");
            ilogger.LogError("Here is error message from our Controller");
            return new string[] { "value1", "value2" };
        }
    }
}
