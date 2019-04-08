using System;
using System.Collections.Generic;

namespace DrawShapesService.SyntaxValidator
{
    public class MeasurementNameSyntaxValidator : ISyntaxValidator
    {
        private readonly HashSet<string> _expectedWords;

        public MeasurementNameSyntaxValidator() => _expectedWords = new HashSet<string>
            {
                Constants.Measurements.Width,
                Constants.Measurements.Base,
                Constants.Measurements.Height,
                Constants.Measurements.SideLength,
                Constants.Measurements.Radius
            };

        public bool IsSyntaxValid(string word) => _expectedWords.Contains(word.ToLower());
    }
}
