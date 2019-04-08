using System;
using System.Collections.Generic;

namespace DrawShapesService.SyntaxValidator
{
    public class ShapeNameSyntaxValidator : ISyntaxValidator
    {
        private readonly HashSet<string> _expectedWords;

        public ShapeNameSyntaxValidator() => _expectedWords = new HashSet<string>
            {
                Constants.Shapes.IsoscelesTriangle,
                Constants.Shapes.Square,
                Constants.Shapes.ScaleneTriangle,
                Constants.Shapes.Parallelogram,
                Constants.Shapes.EquilateralTriangle,
                Constants.Shapes.Pentagon,
                Constants.Shapes.Rectangle,
                Constants.Shapes.Hexagon,
                Constants.Shapes.Heptagon,
                Constants.Shapes.Octagon,
                Constants.Shapes.Circle,
                Constants.Shapes.Oval
            };

        public bool IsSyntaxValid(string word) => _expectedWords.Contains(word.ToLower());
    }
}
