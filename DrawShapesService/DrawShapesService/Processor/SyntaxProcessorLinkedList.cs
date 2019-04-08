using DrawShapesService.Models;
using DrawShapesService.Reader;
using DrawShapesService.SyntaxValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrawShapesService.Processor
{
    public class SyntaxProcessorLinkedList
    {
        public static Node GetSyntaxProcessorLinkedList()
        {
            IDataReader keyReader = new KeyReader();
            IDataReader valueReader = new ValueReader();

            Node root = new Node(new OneWordSyntaxValidator(Constants.Draw), keyReader);
            Node temp = root.NextNode = new Node(new WordListSyntaxValidator(new HashSet<string> { "a", "an" }), null);
            temp = temp.NextNode = new Node(new ShapeNameSyntaxValidator(), valueReader);
            temp = temp.NextNode = new Node(new OneWordSyntaxValidator("with"), null);
            var loopNode = temp = temp.NextNode = new Node(new WordListSyntaxValidator(new HashSet<string> { "a", "an" }), null);
            temp = temp.NextNode = new Node(new MeasurementNameSyntaxValidator(), keyReader);
            temp = temp.NextNode = new Node(new OneWordSyntaxValidator("of"), null);
            temp = temp.NextNode = new Node(new IntegerSyntaxValidator(), valueReader);
            temp = temp.NextNode = new Node(new OneWordSyntaxValidator("and"), null);
            temp.NextNode = loopNode;

            return root;
        }
    }
}
