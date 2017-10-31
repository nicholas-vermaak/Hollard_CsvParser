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
            //A regex could be used, but I would only introduce that for more complex scenarios - I believe the below code is more readable which is why I chose this approach.
            string streetNumber = new string(input.TakeWhile(char.IsDigit).ToArray());
            return input.Replace(streetNumber, "").Trim();
        }
    }
}
