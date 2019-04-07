using System.Collections.Generic;

namespace DrawShapesService.Models
{
    public class Shape
    {
        public string Name { get; set; }
        public int? Width { get; set; }
        public int? Base { get; set; }
        public int? Height { get; set; }
        public int? SideLength { get; set; }
        public int? Radius { get; set; }
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }
}
