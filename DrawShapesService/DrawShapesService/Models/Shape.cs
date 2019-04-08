using System.Collections.Generic;
using System.Linq;

namespace DrawShapesService.Models
{
    public class Shape
    {
        private readonly List<ParsedItem> _items;
        public Shape(List<ParsedItem> items) => _items = items;

        public string Name => _items.Where(x => x.Key.ToLower() == "draw").Select(x => x.Value).First();

        public int? Width => GetValue("width");

        public int? Base => GetValue("base");
        public int? Height => GetValue("height");
        public int? SideLength => GetValue("side_length");

        public int? Radius => GetValue("radius");

        private int? GetValue(string fieldName)
        {
            var fieldValue = _items.Where(x => x.Key.ToLower() == fieldName).Select(x => x.Value).FirstOrDefault();
            if (string.IsNullOrEmpty(fieldValue))
                return null;
            return int.Parse(fieldValue);
        }
    }
}
