using System;
using System.Collections.Generic;

namespace DrawShapesService.SyntaxValidator
{
    public class MeasurementNameSyntaxValidator : ISyntaxValidator
    {
        private readonly HashSet<string> _expectedWords;
        public MeasurementNameSyntaxValidator()
        {
            _expectedWords = new HashSet<string>
            {
                "width",
                "base",
                "height",
                "side_length",
                "radius"
            };
        }
        public bool IsSyntaxValid(string word)
        {
            return _expectedWords.Contains(word.ToLower());
        }
    }
}
