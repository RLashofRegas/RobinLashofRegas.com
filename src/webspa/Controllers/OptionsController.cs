using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using webspa.Options;

namespace webspa.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly IOptionsMonitor<AppOptions> _appOptions;

        public OptionsController(IOptionsMonitor<AppOptions> appOptions)
        {
            _appOptions = appOptions;
        }

        [HttpGet]
        public ActionResult<AppOptions> GetAppOptions()
        {
            return _appOptions
                .CurrentValue;
        }
    }
}