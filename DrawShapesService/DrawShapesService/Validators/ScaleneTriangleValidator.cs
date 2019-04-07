using System.Collections.Generic;

namespace DrawShapesService.Validators
{
    public class ScaleneTriangleValidator : ShapeValidator
    {
        public ScaleneTriangleValidator()
        {
            ExpectedKeys = new List<string>
            {
                "name",
                "height",
                "width",
                "side_length"
            };
        }
    }
}
