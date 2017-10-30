using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hollard.CsvParser2
{
    public static class CsvExtensions
    {
        public static string[] ToCsv(this IList list)
        {
            List<string> output = new List<string>();

            //TODO: Refactor this
            //string headerCsvValue = string.Empty;
            PropertyInfo[] properties = GetListChildObjectType(list).GetRuntimeProperties().ToArray();

            string headerCsvValue = string.Join(",", properties.Select(p=>p.Name));

            //for (int i = 0;  i < properties.Length;  i++)
            //{
            //   headerCsvValue += properties[i].Name;

            //    if (i < properties.Length - 1)
            //    {
            //        headerCsvValue += ",";
            //    }
            //}
            output.Add(headerCsvValue);

            
            bool isHeaderAdded = false;
            foreach (var listItem in list)
            {
                if (!isHeaderAdded)
                {
                    isHeaderAdded = true;
                    
                }
                string bodyOutput = string.Empty;
                for (int i = 0; i < properties.Length; i++)
                {
                    if (properties[i].GetValue(listItem) != null)
                    {
                        bodyOutput += properties[i].GetValue(listItem).ToString();
                    }
                    if (i < properties.Length - 1)
                    {
                        bodyOutput += ",";
                    }
                }
                output.Add(bodyOutput);
            }



            return output.ToArray(); ;
        }
        public static void PopulateFromCsv(this IList list, string[] CsvLines, char[] seperators)
        {
            Type type = GetListChildObjectType(list);

            bool isFirstLine = true;//For now we're asssuming that there is always a header row
            List<string> headerValues = new List<string>();

            for (int i = 0; i < CsvLines.Length; i++)
            {
                if (isFirstLine)
                {
                    headerValues = CsvLines[i].Split(seperators, StringSplitOptions.None).ToList();
                    isFirstLine = false;
                }
                else
                {
                    string[] dataRowValues = CsvLines[i].Split(seperators, StringSplitOptions.None);
                    Object itemToAdd = CreateObject(headerValues.ToArray(), dataRowValues, type);
                    list.Add(itemToAdd);
                }
            }
        }

        private static object CreateObject(string[] headerRowValues, string[] dataRowValues, Type type)
        {
            var listItem = Activator.CreateInstance(type);

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                string propertyName = prop.Name;

                int position = Array.IndexOf(headerRowValues, propertyName);
                if (position > -1)
                {
                    prop.SetValue(listItem,dataRowValues[position]);
                }
            }
            return listItem;
        }

        private static Type GetListChildObjectType(IList list)
        {
            return list.GetType().GetGenericArguments().Single();
        }
    }
}
