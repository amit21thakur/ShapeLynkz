using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrawShapesService.Processor
{
    public class QueryFormatProcessing : IQueryFormatProcessing
    {
        public string FormatQuery(string query)
        {
            query = query.Trim().ToLower();
            query = query.TrimEnd('.');
            for (int i = 0; i < 20; i++)
                query = query.Replace("  ", " ");
            query = query.Replace("isosceles triangle", Constants.Shapes.IsoscelesTriangle);
            query = query.Replace("scalene triangle", Constants.Shapes.ScaleneTriangle);
            query = query.Replace("equilateral triangle", Constants.Shapes.EquilateralTriangle);
            query = query.Replace("side length", Constants.Measurements.SideLength);
            return query;
        }
    }
}
