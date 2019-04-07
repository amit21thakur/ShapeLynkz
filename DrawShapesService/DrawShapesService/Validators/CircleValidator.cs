using System.Collections.Generic;

namespace DrawShapesService.Validators
{
    public class CircleValidator : ShapeValidator
    {
        public CircleValidator()
        {
            ExpectedKeys = new List<string>
            {
                "draw",
                "radius"
            };
        }
    }
}
