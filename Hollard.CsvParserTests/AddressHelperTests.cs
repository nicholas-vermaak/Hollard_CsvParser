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
            Assert.AreEqual("Crimson Rd", AddressHelper.ExtractStreetName("8 Crimson Rd"));
            Assert.AreEqual("Long Lane", AddressHelper.ExtractStreetName("102 Long Lane"));
            
        }
        [TestMethod()]
        public void CanExtractNumericStreetNames()
        {
            Assert.AreEqual("4th Avenue", AddressHelper.ExtractStreetName("94 4th Avenue"));

        }

    }
}