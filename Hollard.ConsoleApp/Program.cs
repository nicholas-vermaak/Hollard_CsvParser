using Hollard.Reporting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hollard.ConsoleApp
{
    class Program
    {
        private const string inputDataFile = @"ReportInput\data.csv";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Hollard Report Generation Tool!");
            Console.WriteLine("Press any key to start generating reports...");
            Console.ReadKey();
            Console.Clear();

            try
            {
                ReportGenerator reportGenerator = new ReportGenerator(inputDataFile);

                string nameFrequencyLocation = reportGenerator.WriteNameFrequencyReport("Name_Frequency.csv");
                string addressOrderedByStreetLocation = reportGenerator.WriteAdressOrderedByStreetReport("Address_OrderedBy_StreetName.csv");

                Console.WriteLine("Successfully generated the following reports:");
                Console.WriteLine();
                Console.WriteLine(nameFrequencyLocation);
                Console.WriteLine(addressOrderedByStreetLocation);


                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error generating reports...");
                Console.ReadKey();
            }



            

        }
    }
}
