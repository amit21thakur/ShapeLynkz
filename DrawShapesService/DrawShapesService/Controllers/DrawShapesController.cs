using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DrawShapesService.Models;
using DrawShapesService.Processor;
using DrawShapesService.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

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
            //Format the input query so that we can ignore things which are not required and making it compatible with our usage
            query = _queryFormatProcesser.FormatQuery(query);

            //The format of the query string - linked list to which helps for the syntax check and also tells what type of information we can read from the given word.
            var node = SyntaxProcessorLinkedList.GetSyntaxProcessorLinkedList();
            var queryWords = query.Split(' ');
            string jsonResult = "[";

            foreach(string word in queryWords)
            {
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

            ParsedItem[] items;
            try
            {
                items = JsonConvert.DeserializeObject<ParsedItem[]>(jsonResult);
            }
            catch (Exception e)
            {
                _logger.LogError($"Json msg was not in correct format: Json [{jsonResult}] and Error: [{e}]");
                return StatusCode(500);
            }

            //As of now the query has passed the syntax check - but still need to check whether its structurally correct, 
            //for example - an invalid query could be "Draw a square with a radius of 200"
            //We need to check for these discrepancies in the following code

            string shapeName = items.Where(x => x.Key.ToLower() == "draw").Select(x => x.Value).First();
            ShapeValidator validator = null;
            switch (shapeName.ToLower())
            {
                case "circle":
                    validator = new CircleValidator();
                    break;
                case "isosceles_triangle":
                    validator = new IsoscelesTriangleValidator();
                    break;
                case "oval":
                    validator = new OvalValidator();
                    break;
                case "parallelogram":
                    validator = new ParallelogramValidator();
                    break;
                case "rectangle":
                    validator = new RectangleValidator();
                    break;
                case "scalene_triangle":
                    validator = new ScaleneTriangleValidator();
                    break;
                default:
                    validator = new RegularPolygonValidator();
                    break;
            }

            if (!validator.Validate(items.ToList()))
            {
                _logger.LogError($"The shape instruction is not a valid supported shape. Query: [{query}]");
                return StatusCode(500);
            }

            return Ok(new Shape(items.ToList()));
        }

    }
}
