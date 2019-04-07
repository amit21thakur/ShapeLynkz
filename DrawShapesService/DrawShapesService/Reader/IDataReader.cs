using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrawShapesService.Models;

namespace DrawShapesService.Reader
{
    public interface IDataReader
    {
        string ReadData(string word, string resultJson);
    }
}
