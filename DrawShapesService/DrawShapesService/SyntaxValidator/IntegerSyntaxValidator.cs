using System;

namespace DrawShapesService.SyntaxValidator
{
    public class IntegerSyntaxValidator : ISyntaxValidator
    {
        public bool IsSyntaxValid(string word) => int.TryParse(word, out int intVal);
    }
}
