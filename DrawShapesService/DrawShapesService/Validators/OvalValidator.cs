using System.Collections.Generic;

namespace DrawShapesService.Validators
{
    public class OvalValidator : ShapeValidator
    {
        public OvalValidator()
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
