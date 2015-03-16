using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcForbiddenIsland.Managers;
using MvcForbiddenIsland.Models;
using System.Collections.Generic;
using MvcForbiddenIsland.Enum;
using MvcForbiddenIsland.Validation.CanMove;
using System.Linq;
using MvcForbiddenIsland.Tests.Managers.Mocks;
using MvcForbiddenIsland.Validation.CanLose.Interface;
using MvcForbiddenIsland.Tests.Managers.Lose.Mocks;


namespace MvcForbiddenIsland.Tests.Managers.Lose
{
    [TestClass]
    public class LoseManagerTest
    {
        const string ISLANDBOARD_CANNONT_BE_NULL = "IslandBoard cannot be null";
        const string CANLOSEVALIDATION_CANNONT_BE_NULL = "CanLoseValidation cannot be null";

        [TestMethod]
        public void ReturnsListValidationResults()
        {
            //Arrange 
            var manager = new LoseManager();
            var islandBoard = new List<IslandTile>();
            var waterLevel = 0;
            var canLoseValidation = new List<ICanLose>();

            //Act 
            var result = manager.HaveTheyLost(islandBoard, waterLevel, canLoseValidation);

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<ValidationResults>));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), ISLANDBOARD_CANNONT_BE_NULL)]
        public void WhenIslandBoardIsNullThrowNullReferenceException()
        {
            //Arrange 
            var manager = new LoseManager();
            var waterLevel = 0;
            var canLoseValidation = new List<ICanLose>();

            //Act 
            var result = manager.HaveTheyLost(null, waterLevel, canLoseValidation);

            //Assert
            Assert.Fail(); // If it gets to this line, no exception was thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), CANLOSEVALIDATION_CANNONT_BE_NULL)]
        public void WhenValidationIsNullThrowNullReferenceException()
        {
            //Arrange 
            var manager = new LoseManager();
            var islandBoard = new List<IslandTile>();
            var waterLevel = 0;
            var canLoseValidation = new List<ICanLose>();

            //Act 
            var result = manager.HaveTheyLost(islandBoard, waterLevel, null);

            //Assert
            Assert.Fail(); // If it gets to this line, no exception was thrown
        }

        [TestMethod]
        public void TakesOneValidValidation()
        {
            //Arrange 
            var manager = new LoseManager();
            var islandBoard = new List<IslandTile>();
            var waterLevel = 0;
            var canLoseValidation = new List<ICanLose>();
            canLoseValidation.Add(new CanLose_Valid());

            //Act 
            var result = manager.HaveTheyLost(islandBoard, waterLevel, canLoseValidation);

            //Assert
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void TakesTwoValidValidation()
        {
            //Arrange 
            var manager = new LoseManager();
            var islandBoard = new List<IslandTile>();
            var waterLevel = 0;
            var canLoseValidation = new List<ICanLose>();
            canLoseValidation.Add(new CanLose_Valid());
            canLoseValidation.Add(new CanLose_Valid());

            //Act 
            var result = manager.HaveTheyLost(islandBoard, waterLevel, canLoseValidation);

            //Assert
            Assert.IsFalse(result.Any());
        }


        [TestMethod]
        public void TakesOneNotValidValidation()
        {
            //Arrange 
            var manager = new LoseManager();
            var islandBoard = new List<IslandTile>();
            var waterLevel = 0;
            var canLoseValidation = new List<ICanLose>();
            canLoseValidation.Add(new CanLose_NotValid());

            //Act 
            var result = manager.HaveTheyLost(islandBoard, waterLevel, canLoseValidation);

            //Assert
            Assert.IsTrue(result.Any());
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].ErrorMessage, LoseManagerTestConstants.CAN_LOSE_ERROR);
        }

        [TestMethod]
        public void TakesTwoNotValidValidation()
        {
            //Arrange 
            var manager = new LoseManager();
            var islandBoard = new List<IslandTile>();
            var waterLevel = 0;
            var canLoseValidation = new List<ICanLose>();
            canLoseValidation.Add(new CanLose_NotValid());
            canLoseValidation.Add(new CanLose_NotValid());

            //Act 
            var result = manager.HaveTheyLost(islandBoard, waterLevel, canLoseValidation);

            //Assert
            Assert.IsTrue(result.Any());
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].ErrorMessage, LoseManagerTestConstants.CAN_LOSE_ERROR);
            Assert.AreEqual(result[0].ErrorMessage, LoseManagerTestConstants.CAN_LOSE_ERROR);
        }

        [TestMethod]
        public void TakesTwoFirstValidSecondNotValidValidation()
        {
            //Arrange 
            var manager = new LoseManager();
            var islandBoard = new List<IslandTile>();
            var waterLevel = 0;
            var canLoseValidation = new List<ICanLose>();
            canLoseValidation.Add(new CanLose_Valid());
            canLoseValidation.Add(new CanLose_NotValid());

            //Act 
            var result = manager.HaveTheyLost(islandBoard, waterLevel, canLoseValidation);

            //Assert
            Assert.IsTrue(result.Any());
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].ErrorMessage, LoseManagerTestConstants.CAN_LOSE_ERROR);
        }

        [TestMethod]
        public void TakesTwoFirstNotValidSecondNotValidValidation()
        {
            //Arrange 
            var manager = new LoseManager();
            var islandBoard = new List<IslandTile>();
            var waterLevel = 0;
            var canLoseValidation = new List<ICanLose>();
            canLoseValidation.Add(new CanLose_NotValid());
            canLoseValidation.Add(new CanLose_Valid());

            //Act 
            var result = manager.HaveTheyLost(islandBoard, waterLevel, canLoseValidation);

            //Assert
            Assert.IsTrue(result.Any());
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].ErrorMessage, LoseManagerTestConstants.CAN_LOSE_ERROR);
        }

        [TestMethod]
        public void TakesCanLoseOnWaterLevelNotValidValidation()
        {
            //Arrange 
            var manager = new LoseManager();
            var islandBoard = new List<IslandTile>();
            var waterLevel = 99;
            var canLoseValidation = new List<ICanLose>();
            canLoseValidation.Add(new CanLose_OnWaterLevel());
   

            //Act 
            var result = manager.HaveTheyLost(islandBoard, waterLevel, canLoseValidation);

            //Assert
            Assert.IsTrue(result.Any());
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].ErrorMessage, LoseManagerTestConstants.CAN_LOSE_ON_WATER_LEVEL_ERROR);
        }

        [TestMethod]
        public void TakesCanLoseOnTileNameNotValidValidation()
        {
            //Arrange 
            var manager = new LoseManager();
            var islandBoard = new List<IslandTile>();
            var waterLevel = 0;
            var canLoseValidation = new List<ICanLose>();
            canLoseValidation.Add(new CanLose_OnTileNameValue());
            islandBoard.Add(new IslandTile() { Name = LoseManagerTestConstants.ERROR_TILE_NAME });

            //Act 
            var result = manager.HaveTheyLost(islandBoard, waterLevel, canLoseValidation);

            //Assert
            Assert.IsTrue(result.Any());
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].ErrorMessage, LoseManagerTestConstants.CAN_LOSE_ON_TILE_ERROR);
        }

    }
}
