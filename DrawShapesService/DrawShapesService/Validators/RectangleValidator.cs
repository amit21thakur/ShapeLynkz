using System.Collections.Generic;

namespace DrawShapesService.Validators
{
    public class RectangleValidator : ShapeValidator
    {
        public RectangleValidator()
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
