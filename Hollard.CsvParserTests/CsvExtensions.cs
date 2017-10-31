using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using Hollard.CsvParserExtensions;
using System.Linq;

namespace Hollard.CsvParserTests
{
    [TestClass]
    public class CsvExtensions
    {
        const string csvBasePath = @"data\";
        const string dataFile = @"data\data.csv";
        List<char> sepeartors = new List<char>() { ',' };

        [TestMethod]
        public void PopulateAListWithObjectFromCsvStrings()
        {
            string[] csvData = GetTestData();
            List<Contact> contactList = new List<Contact>();

            contactList.PopulateFromCsv(csvData, sepeartors.ToArray());
            Assert.AreEqual(8, contactList.Count);
        }

        private string ExtractStreetName(string address)
        {
            return address + "updated";
        }

        [TestMethod]
        public void CanOutputHeadersAsCSV()
        {
            List<Contact> contactList = new List<Contact>();
            contactList.Add(new Contact() { Address = "22 Test Address", FirstName = "Nicholas", LastName = "Vermaak" });

            string[] csvOutput = contactList.ToCsv();
            Assert.AreEqual("FirstName,LastName,Address,PhoneNumber", csvOutput[0]);
        }

        [TestMethod]

        public void CanOutput1DataRowAsCSV()
        {
            List<Contact> contactList = new List<Contact>();
            contactList.Add(new Contact() { Address = "22 Test Address", FirstName = "Nicholas", LastName = "Vermaak", PhoneNumber = "0823302831" });

            string[] csvOutput = contactList.ToCsv();
            Assert.AreEqual(2, csvOutput.Length);
            Assert.AreEqual("FirstName,LastName,Address,PhoneNumber", csvOutput[0]);
            Assert.AreEqual("Nicholas,Vermaak,22 Test Address,0823302831", csvOutput[1]);



        }

        [TestMethod]
        public void CanOutputMultipleDataRowsAsCSV()
        {
            List<Contact> contactList = new List<Contact>();
            string[] testData = GetTestData();

            contactList.PopulateFromCsv(testData, sepeartors.ToArray());
            Assert.AreEqual(8, contactList.Count);

            string[] csvRows = contactList.ToCsv();

            Assert.AreEqual(9, csvRows.Length, "Incorrect number of rows returned");
            Assert.AreEqual("FirstName,LastName,Address,PhoneNumber", csvRows[0], "Header row not returned correctly");
            Assert.AreEqual("Jimmy,Smith,102 Long Lane,29384857", csvRows[1], "First row not returned correctly");
            Assert.AreEqual("Clive,Owen,65 Ambling Way,31214788", csvRows[2], "Second row not returned correctlt");
            Assert.AreEqual("Graham,Brown,94 Roland St,8766556", csvRows[8], "Last row not returned correctlt");
        }

        [TestMethod]
        public void CanOutPutEmptyDataValues()
        {
            List<Contact> contactList = new List<Contact>();
            contactList.Add(new Contact() { Address = "22 Test Address", FirstName = "Nicholas", PhoneNumber = "0823302831" });
            contactList.Add(new Contact() { Address = "22 Test Address", FirstName = "Nicholas", LastName = "Vermaak" });

            string[] csvOutput = contactList.ToCsv();
            Assert.AreEqual(3, csvOutput.Length);
            Assert.AreEqual("FirstName,LastName,Address,PhoneNumber", csvOutput[0]);
            Assert.AreEqual("Nicholas,,22 Test Address,0823302831", csvOutput[1]);
            Assert.AreEqual("Nicholas,Vermaak,22 Test Address,", csvOutput[2]);
        }

        [TestMethod]
        public void CallingPopulateOnEmptyListReturnsJustHeaderValues()
        {
            List<Contact> emptyList = new List<Contact>();
            string[] csvRows = emptyList.ToCsv();

            Assert.AreEqual("FirstName,LastName,Address,PhoneNumber", csvRows[0]);
            Assert.AreEqual(1, csvRows.Length);
        }

        private string[] GetTestData()
        {
            return File.ReadAllLines(dataFile);
        }



    }

    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}

