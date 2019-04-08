using DrawShapesService.Models;
using System.Collections.Generic;
using System.Linq;

namespace DrawShapesService.Validators
{
    public abstract class ShapeValidator
    {
        public List<string> ExpectedKeys { get; set; }

        public bool Validate(List<ParsedItem> items)
        {
            var keys = items.Select(x => x.Key).ToList();
            var firstNotSecond = keys.Except(ExpectedKeys).ToList();
            var secondNotFirst = ExpectedKeys.Except(keys).ToList();
            return firstNotSecond.Count == 0 && secondNotFirst.Count == 0;
        }
    }
}
