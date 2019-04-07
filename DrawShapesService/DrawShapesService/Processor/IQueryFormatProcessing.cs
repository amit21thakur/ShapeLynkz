using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrawShapesService.Processor
{
    public interface IQueryFormatProcessing
    {
        string FormatQuery(string query);
    }
}
