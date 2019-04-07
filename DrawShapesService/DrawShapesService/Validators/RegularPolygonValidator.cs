using System.Collections.Generic;

namespace DrawShapesService.Validators
{
    public class RegularPolygonValidator : ShapeValidator
    {
        public RegularPolygonValidator()
        {
            ExpectedKeys = new List<string>
            {
                "name",
                "side_length"
            };
        }
    }
}
