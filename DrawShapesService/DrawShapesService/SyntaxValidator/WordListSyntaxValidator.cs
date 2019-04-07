using System;
using System.Collections.Generic;

namespace DrawShapesService.SyntaxValidator
{
    public class WordListSyntaxValidator : ISyntaxValidator
    {
        private readonly HashSet<string> _expectedWords;

        public WordListSyntaxValidator(HashSet<string> expectedWords) => _expectedWords = expectedWords;

        public bool IsSyntaxValid(string word) => _expectedWords.Contains(word.ToLower());
    }
}
