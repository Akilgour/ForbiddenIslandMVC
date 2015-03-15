using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcForbiddenIsland.Managers;
using MvcForbiddenIsland.Models;
using System.Collections.Generic;
using MvcForbiddenIsland.Enum;
using MvcForbiddenIsland.Validation.CanMove;
using System.Linq;
using MvcForbiddenIsland.Tests.Managers.Mocks;
 

namespace MvcForbiddenIsland.Tests.Managers
{
  
    [TestClass]
    public class MoveManagerTest
    {
       const string NEED_FOUR_MOVE_TILES = "MoveType four player move tiles";

        [TestMethod]
        public void ReturnsListValidationResults()
        {
            //Arrange 
            var manager = new MoveManager();
           
            var playerMoves = new Dictionary<MoveType, IslandTile>();
            var canMoveValidation = new List<ICanMoveValidation>();

            playerMoves.Add(MoveType.FirstMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.SecondMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.ThirdMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.FourthMyPawnMoveTile, new IslandTile());
            //Act 
            var result = manager.AreMovesValid(playerMoves, canMoveValidation, new Player());

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<ValidationResults>));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "PlayerMoves cannot be null")]
        public void WhenPlayerMovesIsNullThrowNullReferenceException()
        {
            //Arrange 
            var manager = new MoveManager();
            var canMoveValidation = new List<ICanMoveValidation>();

            //Act 
            var result = manager.AreMovesValid(null, canMoveValidation, new Player());

            //Assert
            Assert.Fail(); // If it gets to this line, no exception was thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "CanMoveValidation cannot be null")]
        public void WhenCanMoveValidationIsNullThrowNullReferenceException()
        {
            //Arrange 
            var manager = new MoveManager();
            var playerMoves = new Dictionary<MoveType, IslandTile>();

            //Act 
            var result = manager.AreMovesValid(playerMoves, null, new Player());

            //Assert
            Assert.Fail(); // If it gets to this line, no exception was thrown
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), NEED_FOUR_MOVE_TILES)]
        public void TakesOneFirstMyPawnMoveTilePlayerMove()
        {
            //Arrange 
            var manager = new MoveManager();
            var playerMoves = new Dictionary<MoveType, IslandTile>();
            var canMoveValidation = new List<ICanMoveValidation>();

            playerMoves.Add(MoveType.FirstMyPawnMoveTile, new IslandTile());
            
            //Act 
            var result = manager.AreMovesValid(playerMoves, canMoveValidation, new Player());

            //Assert
            Assert.Fail(); // If it gets to this line, no exception was thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), NEED_FOUR_MOVE_TILES)]
        public void TakesFirstMyPawnMoveTileSecondMyPawnMoveTilePlayerMove()
        {
            //Arrange 
            var manager = new MoveManager();
            var playerMoves = new Dictionary<MoveType, IslandTile>();
            var canMoveValidation = new List<ICanMoveValidation>();

            playerMoves.Add(MoveType.FirstMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.SecondMyPawnMoveTile, new IslandTile());

            //Act 
            var result = manager.AreMovesValid(playerMoves, canMoveValidation, new Player());

            //Assert
            Assert.Fail(); // If it gets to this line, no exception was thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), NEED_FOUR_MOVE_TILES)]
        public void TakesSecondMyPawnMoveTilePlayerMove()
        {
            //Arrange 
            var manager = new MoveManager();
            var playerMoves = new Dictionary<MoveType, IslandTile>();
            var canMoveValidation = new List<ICanMoveValidation>();

            playerMoves.Add(MoveType.SecondMyPawnMoveTile, new IslandTile());

            //Act 
            var result = manager.AreMovesValid(playerMoves, canMoveValidation, new Player());

            //Assert
            Assert.Fail(); // If it gets to this line, no exception was thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), NEED_FOUR_MOVE_TILES)]
        public void TakesSecondMyPawnMoveTileThirdMyPawnMoveTilePlayerMove()
        {
            //Arrange 
            var manager = new MoveManager();
            var playerMoves = new Dictionary<MoveType, IslandTile>();
            var canMoveValidation = new List<ICanMoveValidation>();

            playerMoves.Add(MoveType.SecondMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.ThirdMyPawnMoveTile, new IslandTile());

            //Act 
            var result = manager.AreMovesValid(playerMoves, canMoveValidation, new Player());

            //Assert
            Assert.Fail(); // If it gets to this line, no exception was thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), NEED_FOUR_MOVE_TILES)]
        public void TakesFirstMyPawnMoveTileThirdMyPawnMoveTilePlayerMove()
        {
            //Arrange 
            var manager = new MoveManager();
            var playerMoves = new Dictionary<MoveType, IslandTile>();
            var canMoveValidation = new List<ICanMoveValidation>();

            playerMoves.Add(MoveType.FirstMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.ThirdMyPawnMoveTile, new IslandTile());

            //Act 
            var result = manager.AreMovesValid(playerMoves, canMoveValidation, new Player());

            //Assert
            Assert.Fail(); // If it gets to this line, no exception was thrown
        }


        [TestMethod]
        public void TakesOneValidValidation()
        {
            //Arrange 
            var manager = new MoveManager();
            var playerMoves = new Dictionary<MoveType, IslandTile>();
            var canMoveValidation = new List<ICanMoveValidation>();

            playerMoves.Add(MoveType.FirstMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.SecondMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.ThirdMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.FourthMyPawnMoveTile, new IslandTile());

            canMoveValidation.Add(new CanMove_Valid());

            //Act 
            var result = manager.AreMovesValid(playerMoves, canMoveValidation, new Player());

            //Assert
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void TakesTwoValidValidation()
        {
            //Arrange 
            var manager = new MoveManager();
            var playerMoves = new Dictionary<MoveType, IslandTile>();
            var canMoveValidation = new List<ICanMoveValidation>();

            playerMoves.Add(MoveType.FirstMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.SecondMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.ThirdMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.FourthMyPawnMoveTile, new IslandTile());

            canMoveValidation.Add(new CanMove_Valid());
            canMoveValidation.Add(new CanMove_Valid());

            //Act 
            var result = manager.AreMovesValid(playerMoves, canMoveValidation, new Player());

            //Assert
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void TakesOneNotValidValidation()
        {
            //Arrange 
            var manager = new MoveManager();
            var playerMoves = new Dictionary<MoveType, IslandTile>();
            var canMoveValidation = new List<ICanMoveValidation>();

            playerMoves.Add(MoveType.FirstMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.SecondMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.ThirdMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.FourthMyPawnMoveTile, new IslandTile());

            canMoveValidation.Add(new CanMove_NotValid());

            //Act 
            var result = manager.AreMovesValid(playerMoves, canMoveValidation, new Player());

            //Assert
            Assert.IsTrue(result.Any());
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result[0].ErrorMessage, ManagersTestConstants.CAN_MOVE_ERROR);
            Assert.AreEqual(result[1].ErrorMessage, ManagersTestConstants.CAN_MOVE_ERROR);
            Assert.AreEqual(result[2].ErrorMessage, ManagersTestConstants.CAN_MOVE_ERROR);

        }

        [TestMethod]
        public void TakesTwoNotValidValidation()
        {
            //Arrange 
            var manager = new MoveManager();
            var playerMoves = new Dictionary<MoveType, IslandTile>();
            var canMoveValidation = new List<ICanMoveValidation>();

            playerMoves.Add(MoveType.FirstMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.SecondMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.ThirdMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.FourthMyPawnMoveTile, new IslandTile());

            canMoveValidation.Add(new CanMove_NotValid());
            canMoveValidation.Add(new CanMove_NotValid());

            //Act 
            var result = manager.AreMovesValid(playerMoves, canMoveValidation, new Player());

            //Assert
            Assert.IsTrue(result.Any());
            Assert.AreEqual(result.Count, 6);
            Assert.AreEqual(result[0].ErrorMessage, ManagersTestConstants.CAN_MOVE_ERROR);
            Assert.AreEqual(result[1].ErrorMessage, ManagersTestConstants.CAN_MOVE_ERROR);
            Assert.AreEqual(result[2].ErrorMessage, ManagersTestConstants.CAN_MOVE_ERROR);
            Assert.AreEqual(result[3].ErrorMessage, ManagersTestConstants.CAN_MOVE_ERROR);
            Assert.AreEqual(result[4].ErrorMessage, ManagersTestConstants.CAN_MOVE_ERROR);
            Assert.AreEqual(result[5].ErrorMessage, ManagersTestConstants.CAN_MOVE_ERROR);


        }


        [TestMethod]
        public void TakesOneFailValidOnNameValidationErrorOnFirstTile()
        {
            //Arrange 
            var manager = new MoveManager();
            var playerMoves = new Dictionary<MoveType, IslandTile>();
            var canMoveValidation = new List<ICanMoveValidation>();

            playerMoves.Add(MoveType.FirstMyPawnMoveTile, new IslandTile() { Name = ManagersTestConstants.ERROR_TILE_NAME });
            playerMoves.Add(MoveType.SecondMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.ThirdMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.FourthMyPawnMoveTile, new IslandTile());

            canMoveValidation.Add(new CanMove_ErrorOnName());

            //Act 
            var result = manager.AreMovesValid(playerMoves, canMoveValidation, new Player());

            //Assert
            Assert.IsTrue(result.Any());
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].ErrorMessage, ManagersTestConstants.CAN_MOVE_ERROR);
        }

        [TestMethod]
        public void TakesOneFailValidOnNameValidationErrorOnSecondTile()
        {
            //Arrange 
            var manager = new MoveManager();
            var playerMoves = new Dictionary<MoveType, IslandTile>();
            var canMoveValidation = new List<ICanMoveValidation>();

            playerMoves.Add(MoveType.FirstMyPawnMoveTile, new IslandTile() );
            playerMoves.Add(MoveType.SecondMyPawnMoveTile, new IslandTile() { Name = ManagersTestConstants.ERROR_TILE_NAME });
            playerMoves.Add(MoveType.ThirdMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.FourthMyPawnMoveTile, new IslandTile());

            canMoveValidation.Add(new CanMove_ErrorOnName());

            //Act 
            var result = manager.AreMovesValid(playerMoves, canMoveValidation, new Player());

            //Assert
            Assert.IsTrue(result.Any());
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].ErrorMessage, ManagersTestConstants.CAN_MOVE_ERROR);
            Assert.AreEqual(result[1].ErrorMessage, ManagersTestConstants.CAN_MOVE_ERROR);

        }


        [TestMethod]
        public void TakesOneFailValidOnNameValidationErrorOnThirdTile()
        {
            //Arrange 
            var manager = new MoveManager();
            var playerMoves = new Dictionary<MoveType, IslandTile>();
            var canMoveValidation = new List<ICanMoveValidation>();

            playerMoves.Add(MoveType.FirstMyPawnMoveTile, new IslandTile() );
            playerMoves.Add(MoveType.SecondMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.ThirdMyPawnMoveTile, new IslandTile() { Name = ManagersTestConstants.ERROR_TILE_NAME });
            playerMoves.Add(MoveType.FourthMyPawnMoveTile, new IslandTile());

            canMoveValidation.Add(new CanMove_ErrorOnName());

            //Act 
            var result = manager.AreMovesValid(playerMoves, canMoveValidation, new Player());

            //Assert
            Assert.IsTrue(result.Any());
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].ErrorMessage, ManagersTestConstants.CAN_MOVE_ERROR);
            Assert.AreEqual(result[1].ErrorMessage, ManagersTestConstants.CAN_MOVE_ERROR);
        }


        [TestMethod]
        public void TakesOneFailValidOnNameValidationErrorOnFourthTile()
        {
            //Arrange 
            var manager = new MoveManager();
            var playerMoves = new Dictionary<MoveType, IslandTile>();
            var canMoveValidation = new List<ICanMoveValidation>();

            playerMoves.Add(MoveType.FirstMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.SecondMyPawnMoveTile, new IslandTile());
            playerMoves.Add(MoveType.ThirdMyPawnMoveTile, new IslandTile() );
            playerMoves.Add(MoveType.FourthMyPawnMoveTile, new IslandTile() { Name = ManagersTestConstants.ERROR_TILE_NAME });

            canMoveValidation.Add(new CanMove_ErrorOnName());

            //Act 
            var result = manager.AreMovesValid(playerMoves, canMoveValidation, new Player());

            //Assert
            Assert.IsTrue(result.Any());
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].ErrorMessage, ManagersTestConstants.CAN_MOVE_ERROR);
        }
    }
}
