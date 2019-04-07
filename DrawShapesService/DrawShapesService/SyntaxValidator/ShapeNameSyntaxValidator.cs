using System;
using System.Collections.Generic;

namespace DrawShapesService.SyntaxValidator
{
    public class ShapeNameSyntaxValidator : ISyntaxValidator
    {
        private readonly HashSet<string> _expectedWords;
        public ShapeNameSyntaxValidator()
        {
            _expectedWords = new HashSet<string>
            {
                "isosceles_triangle",
                "square",
                "scalene_triangle",
                "parallelogram",
                "equilateral_triangle",
                "pentagon",
                "rectangle",
                "hexagon",
                "heptagon",
                "octagon",
                "circle",
                "oval"
            };

        }
        public bool IsSyntaxValid(string word)
        {
            return _expectedWords.Contains(word.ToLower());
        }
    }
}
