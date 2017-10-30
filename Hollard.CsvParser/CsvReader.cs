using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Hollard.CsvParser
{
    public class CsvReader:ICsvReader
    {
        private char[] seperators = new char[] { ',' };

        public IEnumerable<T> ReadCsv<T>(string CsvPath) where T:new()
        {
            if (string.IsNullOrEmpty(CsvPath))
            {
                throw new ArgumentException("CSV Path cannot be null or empty");
            }

            if (!File.Exists(CsvPath))
            {
                throw new FileNotFoundException();
            }

            List<T> returnList = new List<T>();
            List<string> csvHeaderValues = new List<string>();
            bool isHeaderLine = true;
            IEnumerable<PropertyInfo> properties = typeof(T).GetRuntimeProperties();

            foreach (string csvLine in File.ReadAllLines(CsvPath))
            {
                if (isHeaderLine)
                {
                    csvHeaderValues = csvLine.Split(seperators).ToList();
                    isHeaderLine = false;
                }
                else
                {
                    T csvObject = CsvLineToObject<T>(csvHeaderValues, properties, csvLine);
                    returnList.Add(csvObject);
                }
            }
            return returnList;
        }

        private T CsvLineToObject<T>(List<string> csvHeaderValues, IEnumerable<PropertyInfo> properties, string csvLine) where T : new()
        {
            string[] dataLineValues = csvLine.Split(seperators);
            var obj = new T();

            for (int i = 0; i < csvHeaderValues.Count; i++)
            {
                PropertyInfo pi = properties.Where(p => p.Name == csvHeaderValues[i]).FirstOrDefault();
                pi?.SetValue(obj, dataLineValues[i]);
            }
            return obj;
        }
    }
}


//Assumptions
//Just handle comma delimited - no need for other delimiters
//CSV will always have a header.
//This version is an MVP that handles string values (other data types have not been implemented)

//Resources I found interesting
//https://stackoverflow.com/questions/43021/how-do-you-get-the-index-of-the-current-iteration-of-a-foreach-loop