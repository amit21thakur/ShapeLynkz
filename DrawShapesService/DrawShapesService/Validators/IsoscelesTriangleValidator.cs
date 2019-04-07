using System.Collections.Generic;

namespace DrawShapesService.Validators
{
    public class IsoscelesTriangleValidator : ShapeValidator
    {
        public IsoscelesTriangleValidator()
        {
            ExpectedKeys = new List<string>
            {
                "name",
                "height",
                "width"
            };
        }
    }
}
