using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hollard.CsvParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Hollard.CsvParser.Tests
{
    [TestClass()]
    public class AddressHelperTests
    {
        [TestMethod()]
        public void CanExtractStreetName()
        {
            string outStr = AddressHelper.ExtractStreetName("102 Long Lane");
            Assert.AreEqual("Crimson Rd", AddressHelper.ExtractStreetName("8 Crimson Rd"));
            Assert.AreEqual("4th Avenue", AddressHelper.ExtractStreetName("94 4th Avenue"));
            Assert.AreEqual("Long Lane", AddressHelper.ExtractStreetName("102 Long Lane"));
            
        }
    }
}