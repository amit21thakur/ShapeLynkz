using System.Collections.Generic;

namespace DrawShapesService.Validators
{
    public class OvalValidator : ShapeValidator
    {
        public OvalValidator()
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
