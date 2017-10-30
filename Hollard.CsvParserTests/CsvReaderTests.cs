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
    public class CsvReaderTests
    {
        const string csvFilePath = @"data\data.csv";

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void NullCSVPathShouldThrowException()
        {
            CsvReader csvReader = new CsvReader();
            IEnumerable<Contact> returnValue = csvReader.ReadCsv<Contact>(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void InvalidCSVPathShouldThrowException()
        {
            CsvReader csvReader = new CsvReader();
            IEnumerable<Contact> returnValue = csvReader.ReadCsv<Contact>("c:\\DoesNotExist.csv");
        }


        [TestMethod()]
        public void EnsureAllRecordsAreReturned()
        {
            CsvReader csvReader = new CsvReader();
            IEnumerable<Contact> returnValue = csvReader.ReadCsv<Contact>(csvFilePath);

            Assert.AreEqual(8, returnValue.Count());
        }

        [TestMethod()]
        public void EnsureCorrectRecordsReturned()
        {
            CsvReader csvReader = new CsvReader();
            IEnumerable<Contact> actualContactList = csvReader.ReadCsv<Contact>(csvFilePath);
            var firstContactActual = actualContactList.FirstOrDefault();
            var lastContactActual = actualContactList.LastOrDefault();

            Assert.AreEqual("Jimmy", firstContactActual.FirstName);
            Assert.AreEqual("Smith", firstContactActual.LastName);
            Assert.AreEqual("102 Long Lane", firstContactActual.Address);
            Assert.AreEqual("29384857", firstContactActual.PhoneNumber);

            Assert.AreEqual("Graham", lastContactActual.FirstName);
            Assert.AreEqual("Brown", lastContactActual.LastName);
            Assert.AreEqual("94 Roland St", lastContactActual.Address);
            Assert.AreEqual("8766556", lastContactActual.PhoneNumber);
        }
    }

    public class Contact {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }



}