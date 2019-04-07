using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DrawShapesService.Controllers
{
    [Route("api/pars")]
    public class DrawShapesController : Controller
    {
        private readonly ILogger _logger;


        public DrawShapesController(ILogger<DrawShapesController> logger )
        {
            _logger = logger; 
        }

        // GET api/shape
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {

            return Ok();
        }

    }
}
