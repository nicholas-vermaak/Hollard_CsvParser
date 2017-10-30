using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hollard.CsvParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hollard.CsvParser.Tests
{
    [TestClass()]
    public class CsvWriterTests
    {
        const string csvBasePath = @"data\";

        private IEnumerable<ContactReport> GenerateTestData()
        {
            List<ContactReport> contactReport = new List<ContactReport>();
            contactReport.Add(new ContactReport() { FirstName = "Nicholas", LastName = "Vermaak" });
            contactReport.Add(new ContactReport() { FirstName = "Kirstey", LastName = "Vermaak" });
            return contactReport;

        }
    }

 
    public class ContactReport
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}