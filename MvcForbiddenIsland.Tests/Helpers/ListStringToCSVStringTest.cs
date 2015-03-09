using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MvcForbiddenIsland.Helpers;

namespace MvcForbiddenIsland.Tests.Helpers
{
    [TestClass]
    public class ListStringToCSVStringTest
    {
        [TestMethod]
        public void NullListReurnStringEmpty()
        {
            //Arrange 
            List<string> stringList = null;

            //Act 
            var results = ListStringToCSVString.ListToString(stringList);

            //Assert
            Assert.AreEqual(results, "");
        }

        [TestMethod]
        public void NewListReurnStringEmpty()
        {
            //Arrange 
            List<string> stringList = new List<string>();

            //Act 
            var results = ListStringToCSVString.ListToString(stringList);

            //Assert
            Assert.AreEqual(results, "");
        }

        [TestMethod]
        public void ListWithOneItemReurnStringEmpty()
        {
            //Arrange 
            List<string> stringList = new List<string>();
            stringList.Add("A");
            //Act 
            var results = ListStringToCSVString.ListToString(stringList);

            //Assert
            Assert.AreEqual(results, "A");
        }

        [TestMethod]
        public void ListWithTwoItemsReurnStringEmpty()
        {
            //Arrange 
            List<string> stringList = new List<string>();
            stringList.Add("A");
            stringList.Add("B");

            //Act 
            var results = ListStringToCSVString.ListToString(stringList);

            //Assert
            Assert.AreEqual(results, "A and B");
        }

        [TestMethod]
        public void ListWithThreeItemsReurnStringEmpty()
        {
            //Arrange 
            List<string> stringList = new List<string>();
            stringList.Add("A");
            stringList.Add("B");
            stringList.Add("C");

            //Act 
            var results = ListStringToCSVString.ListToString(stringList);

            //Assert
            Assert.AreEqual(results, "A, B and C");
        }


        [TestMethod]
        public void ListWithThreeItemsOutOfOrderReurnStringEmpty()
        {
            //Arrange 
            List<string> stringList = new List<string>();
            stringList.Add("C");
            stringList.Add("A");
            stringList.Add("B");

            //Act 
            var results = ListStringToCSVString.ListToString(stringList);

            //Assert
            Assert.AreEqual(results, "A, B and C");
        }
    }
}
