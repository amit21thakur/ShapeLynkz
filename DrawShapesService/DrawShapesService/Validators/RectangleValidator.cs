using System.Collections.Generic;

namespace DrawShapesService.Validators
{
    public class RectangleValidator : ShapeValidator
    {
        public RectangleValidator()
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
