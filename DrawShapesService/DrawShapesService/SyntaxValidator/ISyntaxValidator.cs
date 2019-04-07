using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrawShapesService.SyntaxValidator
{
    public interface ISyntaxValidator
    {
        bool IsSyntaxValid(string word);
    }
}
