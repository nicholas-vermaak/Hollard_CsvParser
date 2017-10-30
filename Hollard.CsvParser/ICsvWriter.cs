using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hollard.CsvParser
{
    public interface ICsvWriter
    {
        //IEnumerable<T> WriteCsvFile<T>(string CSVPath) where T : new();
        void GenerateCSV(IEnumerable<object> DataList, string DestinationFilePath);
    }
}
