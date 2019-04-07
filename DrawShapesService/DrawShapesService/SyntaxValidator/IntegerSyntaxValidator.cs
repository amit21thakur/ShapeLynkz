using System;

namespace DrawShapesService.SyntaxValidator
{
    public class IntegerSyntaxValidator : ISyntaxValidator
    {
        public bool IsSyntaxValid(string word)
        {
            return int.TryParse(word, out int intVal);
        }
    }
}
