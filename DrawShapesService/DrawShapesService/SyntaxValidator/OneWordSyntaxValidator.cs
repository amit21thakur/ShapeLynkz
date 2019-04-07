using System;

namespace DrawShapesService.SyntaxValidator
{
    public class OneWordSyntaxValidator : ISyntaxValidator
    {
        private readonly string _expectedWord;

        public OneWordSyntaxValidator(string expectedWord) => _expectedWord = expectedWord;

        public bool IsSyntaxValid(string word) => string.Compare(_expectedWord, word, StringComparison.InvariantCultureIgnoreCase) == 0;
    }
}
