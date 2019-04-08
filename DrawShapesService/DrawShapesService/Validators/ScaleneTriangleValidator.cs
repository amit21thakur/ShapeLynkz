using System.Collections.Generic;

namespace DrawShapesService.Validators
{
    public class ScaleneTriangleValidator : ShapeValidator
    {
        public ScaleneTriangleValidator()
        {
            ExpectedKeys = new List<string>
            {
                Constants.Draw,
                Constants.Measurements.Height,
                Constants.Measurements.Width,
                Constants.Measurements.SideLength
            };
        }
    }
}
