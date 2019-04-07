using DrawShapesService.Reader;
using DrawShapesService.SyntaxValidator;

namespace DrawShapesService.Models
{
    public class Node
    {
        public Node(ISyntaxValidator syntaxValidator, IDataReader reader)
        {
            _syntaxValidator = syntaxValidator;
            _reader = reader;
        }

        //To Validate the syntax of a given node
        private readonly ISyntaxValidator _syntaxValidator;

        /// <summary>
        /// Could be set to null, or could key data or value data
        /// </summary>
        private readonly IDataReader _reader;

        public ISyntaxValidator SyntaxValidator => _syntaxValidator;
        public IDataReader DataReader => _reader;

        public Node NextNode { get; set; }
    }
}
