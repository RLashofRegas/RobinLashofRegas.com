using Microsoft.AspNetCore.Mvc;
using webspa.Options;

namespace webspa.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly AppOptions _appOptions;

        public OptionsController(AppOptions appOptions)
        {
            _appOptions = appOptions;
        }

        [HttpGet]
        public ActionResult<AppOptions> GetAppOptions()
        {
            return _appOptions;
        }
    }
}