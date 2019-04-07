using System.Collections.Generic;

namespace DrawShapesService.Validators
{
    public class ParallelogramValidator : ShapeValidator
    {
        public ParallelogramValidator()
        {
            ExpectedKeys = new List<string>
            {
                "name",
                "height",
                "width",
                "base"
            };
        }
    }
}
