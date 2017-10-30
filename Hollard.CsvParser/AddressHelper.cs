using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hollard.CsvParser
{
    public static class AddressHelper
    {
        public static string ExtractStreetName(string input)
        {
            //Find n number of numbers at beginning of string and remove
            var returnValue = input.Split(new char[] {' '});
            

            return returnValue.Concat()
        }
    }
}
