using System.Threading.Tasks;
using DrawShapesService.Processor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DrawShapesService.Controllers
{
    [Route("api/shape")]
    public class DrawShapesController : Controller
    {
        private readonly ILogger _logger;
        private readonly IQueryFormatProcessing _queryFormatProcesser;

        public DrawShapesController(IQueryFormatProcessing queryFormatProcesser, ILogger<DrawShapesController> logger )
        {
            _queryFormatProcesser = queryFormatProcesser;
            _logger = logger; 
        }

        // GET api/shape
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            query = _queryFormatProcesser.FormatQuery(query);
            var node = SyntaxProcessorLinkedList.GetSyntaxProcessorLinkedList();
            var queryWords = query.Split(' ');
            string jsonResult = "[";

            for(int i=0; i<queryWords.Length; i++)
            {
                string word = queryWords[i];
                if (!node.SyntaxValidator.IsSyntaxValid(word))
                {
                    return StatusCode(500);
                }
                if(node.DataReader!=null)
                {
                    jsonResult = node.DataReader.ReadData(word, jsonResult);
                }
                node = node.NextNode;
            }
            jsonResult = jsonResult.TrimEnd(',') + "]";

            return Ok();
        }

    }
}
