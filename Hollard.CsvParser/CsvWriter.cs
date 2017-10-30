using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hollard.CsvParser
{
    public class CsvWriter : ICsvWriter
    {
        public void GenerateCSV(IEnumerable<object> DataList, string DestinationFilePath)
        {

            if (DataList is null || DataList.Count() < 1)
            {
                throw new ArgumentException("Argument Datalist cannot be null or empty");
            }

            bool isFirstRowWritten = false;
            IEnumerable<PropertyInfo> properties = DataList.First().GetType().GetRuntimeProperties();
            
            foreach (object row in DataList)
            {
                
            }
        }

   
    }
}
