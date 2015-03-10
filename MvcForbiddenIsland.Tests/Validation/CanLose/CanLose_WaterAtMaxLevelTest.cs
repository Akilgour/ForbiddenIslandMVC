using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcForbiddenIsland.Models;
using System.Collections.Generic;
using MvcForbiddenIsland.Constants;
using MvcForbiddenIsland.Factory;
using System.Linq;
using MvcForbiddenIsland.Validation.CanLose;
using MvcForbiddenIsland.Enum;

namespace MvcForbiddenIsland.Tests.Validation.CanLose
{
    [TestClass]
   public class CanLose_WaterAtMaxLevelTest
    {

        [TestMethod]
        public void WaterAtOne()
        {
            //Arrange 
            var canLose = new CanLose_WaterAtMaxLevel();
            var islandTile = new IslandTile();

            //Act 
            var result = canLose.IsValid(null, 1);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void WaterAtTwo()
        {
            //Arrange 
            var canLose = new CanLose_WaterAtMaxLevel();
            var islandTile = new IslandTile();

            //Act 
            var result = canLose.IsValid(null, 2);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void WaterAtThree()
        {
            //Arrange 
            var canLose = new CanLose_WaterAtMaxLevel();
            var islandTile = new IslandTile();

            //Act 
            var result = canLose.IsValid(null, 3);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void WaterAtFour()
        {
            //Arrange 
            var canLose = new CanLose_WaterAtMaxLevel();
            var islandTile = new IslandTile();

            //Act 
            var result = canLose.IsValid(null, 4);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void WaterAtFive()
        {
            //Arrange 
            var canLose = new CanLose_WaterAtMaxLevel();
            var islandTile = new IslandTile();

            //Act 
            var result = canLose.IsValid(null, 5);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void WaterAtSix()
        {
            //Arrange 
            var canLose = new CanLose_WaterAtMaxLevel();
            var islandTile = new IslandTile();

            //Act 
            var result = canLose.IsValid(null, 6);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void WaterAtSeven()
        {
            //Arrange 
            var canLose = new CanLose_WaterAtMaxLevel();
            var islandTile = new IslandTile();

            //Act 
            var result = canLose.IsValid(null, 7);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void WaterAtEight()
        {
            //Arrange 
            var canLose = new CanLose_WaterAtMaxLevel();
            var islandTile = new IslandTile();
          
            //Act 
            var result = canLose.IsValid(null, 8);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void WaterAtNine()
        {
            //Arrange 
            var canLose = new CanLose_WaterAtMaxLevel();
            var islandTile = new IslandTile();

            //Act 
            var result = canLose.IsValid(null, 9);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }


        [TestMethod]
        public void WaterAtTen()
        {
            //Arrange 
            var canLose = new CanLose_WaterAtMaxLevel();
            var islandTile = new IslandTile();

            //Act 
            var result = canLose.IsValid(null, 10);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CanLoseConstants.ISLAND_IS_GONE);
        }

        [TestMethod]
        public void WaterAtEleven()
        {
            //Arrange 
            var canLose = new CanLose_WaterAtMaxLevel();
            var islandTile = new IslandTile();

            //Act 
            var result = canLose.IsValid(null, 11);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CanLoseConstants.ISLAND_IS_GONE);
        }
    }
}
