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
            for (int i = 0; i < 20; i++)
                query = query.Replace("  ", " ");
            query = query.Replace("isosceles triangle", "isosceles_triangle");
            query = query.Replace("scalene triangle", "scalene_triangle");
            query = query.Replace("equilateral triangle", "equilateral_triangle");
            query = query.Replace("side length", "side_length");
            return query;
        }
    }
}
