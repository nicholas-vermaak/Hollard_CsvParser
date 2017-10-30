using System;
using System.Collections.Generic;
using System.Text;

namespace Hollard.CsvParser
{
    public interface ICsvReader
    {
        IEnumerable<T> ReadCsv<T>(string CSVPath) where T : new();
    }
}
