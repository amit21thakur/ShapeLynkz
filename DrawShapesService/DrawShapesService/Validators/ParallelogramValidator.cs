using System.Collections.Generic;

namespace DrawShapesService.Validators
{
    public class ParallelogramValidator : ShapeValidator
    {
        public ParallelogramValidator()
        {
            ExpectedKeys = new List<string>
            {
                Constants.Draw,
                Constants.Measurements.Height,
                Constants.Measurements.Width,
                Constants.Measurements.Base
            };
        }
    }
}
