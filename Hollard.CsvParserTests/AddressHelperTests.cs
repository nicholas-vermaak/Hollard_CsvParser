using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hollard.CsvParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hollard.CsvParser.Tests
{
    [TestClass()]
    public class AddressHelperTests
    {
        [TestMethod()]
        public void CanExtractStreetName()
        {
            //string input = "102 Long Lane";
            //string output = AddressHelper.ExtractStreetName(input);

            //Assert.AreEqual("Long Lane", output);
        }

        private List<string> GetTestData()
        {
            List<string> returnData = new List<string>();
            returnData.Add("94 4th Avenue");
            returnData.Add("102 Long Lane");
            returnData.Add("65 Ambling Way");
            returnData.Add("82 Stewart St");
            returnData.Add("12 Howard St");
            returnData.Add("78 Short Lane");
            returnData.Add("49 Sutherland St");
            returnData.Add("8 Crimson Rd");
            returnData.Add("94 Roland St");


            return returnData;
        }
    }
}