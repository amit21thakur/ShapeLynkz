using System.Collections.Generic;
using System.Linq;

namespace DrawShapesService.Models
{
    public class Shape
    {
        private readonly List<ParsedItem> _items;
        public Shape(List<ParsedItem> items) => _items = items;

        public string Name => _items.Where(x => x.Key.ToLower() == Constants.Draw).Select(x => x.Value).First();

        public int? Width => GetValue(Constants.Measurements.Width);

        public int? Base => GetValue(Constants.Measurements.Base);
        public int? Height => GetValue(Constants.Measurements.Height);
        public int? SideLength => GetValue(Constants.Measurements.SideLength);

        public int? Radius => GetValue(Constants.Measurements.Radius);

        private int? GetValue(string fieldName)
        {
            var fieldValue = _items.Where(x => x.Key.ToLower() == fieldName).Select(x => x.Value).FirstOrDefault();
            if (string.IsNullOrEmpty(fieldValue))
                return null;
            return int.Parse(fieldValue);
        }
    }
}
