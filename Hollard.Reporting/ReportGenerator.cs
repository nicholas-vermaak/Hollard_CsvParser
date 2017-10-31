using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hollard.CsvParserExtensions;
using System.IO;
using Hollard.CsvParser;

namespace Hollard.Reporting
{
    public class ReportGenerator
    {
        private List<Client> clientList;
        private char[] seperator = new char[1] { ',' };

        public ReportGenerator(string InputFile)
        {
            clientList = PopulateListFromCSV(InputFile);
        }

        public string WriteNameFrequencyReport(string Filename)
        {
            var firstNameList = clientList.Select(c => new { NameKey = c.FirstName });
            var lastNameList = clientList.Select(c => new { NameKey = c.LastName });

            var reportQuery = firstNameList.Concat(lastNameList)
                            .GroupBy(c => c.NameKey)
                            .Select(grp => new
                            {
                                NameKey = grp.Key,
                                Frequency = grp.Count()
                            })
                            .OrderByDescending(c => c.Frequency)
                            .ThenBy(c => c.NameKey)
                            .ToList();

            return WriteReportToDisk(reportQuery.ToCsv(), Filename);
        }

        public string WriteAdressOrderedByStreetReport(string Filename)
        {
            var reportQuery = clientList.Select(c => new
            {
                c.Address,
                StreetName = AddressHelper.ExtractStreetName(c.Address)
            })
            .OrderBy(c=>c.StreetName)
            .Select(c=> new {c.Address })
            .ToList();

            return WriteReportToDisk(reportQuery.ToCsv(), Filename);
        }

        private string WriteReportToDisk(string[] CsvRows, string Filename)
        {
            string fullPath = System.IO.Path.GetFullPath(Filename);
            File.WriteAllLines(fullPath, CsvRows);
            return fullPath;
        }
        private List<Client> PopulateListFromCSV(string CsvLocation)
        {
            List<Client> returnList = new List<Client>();

            string[] csvRows = File.ReadAllLines(CsvLocation);
            returnList.PopulateFromCsv(csvRows, seperator);

            return returnList;
        }




    }
}
