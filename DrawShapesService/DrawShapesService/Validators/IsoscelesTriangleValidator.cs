using System.Collections.Generic;

namespace DrawShapesService.Validators
{
    public class IsoscelesTriangleValidator : ShapeValidator
    {
        public IsoscelesTriangleValidator()
        {
            ExpectedKeys = new List<string>
            {
                Constants.Draw,
                Constants.Measurements.Height,
                Constants.Measurements.Width
            };
        }
    }
}
